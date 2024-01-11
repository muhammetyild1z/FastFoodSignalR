using AutoMapper;
using FastFoodSignalR.DtoLayer.AccountDtos;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password, signInDto.RememberMe, true);
            if (result.Succeeded)
            {
                return Ok();
            }
            if (result.IsLockedOut)
            {
                return StatusCode(423, "Hesap Kilitli Durumda");
            }
            if (result.RequiresTwoFactor)
            {
                return StatusCode(428, "Two-factor Doğrulaması yapılmadı");
            }
            else
            {
                return StatusCode(401, result.ToString());
            }

        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var emailCheck = await _userManager.FindByEmailAsync(signUpDto.Email);
           
            if (signUpDto.Password == signUpDto.PasswordConfirm)
            {
                var result = await _userManager.CreateAsync(_mapper.Map<AppUser>(signUpDto), signUpDto.Password);
                if (ModelState.IsValid)
                {
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else if (emailCheck != null)
                    {

                        return StatusCode(400, "Bu Mail Adresi Kayitli");
                    }
                }
               
                else 
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("UserName", item.Description);
                    }
                }
             
            }
          
            return StatusCode( 404 ,"Hata Yoneticiyle Iletisime Gecin.");
        }
        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}

