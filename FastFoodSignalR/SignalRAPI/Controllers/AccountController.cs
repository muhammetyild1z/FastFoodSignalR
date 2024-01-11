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
            var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password,signInDto.RememberMe,true);
            if (result.Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var emailCheck = await _userManager.FindByEmailAsync(signUpDto.Email);
            var userNameCheck = await _userManager.FindByNameAsync(signUpDto.UserName);
            if (signUpDto.Password==signUpDto.PasswordConfirm && emailCheck==null && userNameCheck==null )
            {
                var result = await _userManager.CreateAsync(_mapper.Map<AppUser>(signUpDto), signUpDto.Password);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }         
            return NotFound();
        }
       
        //public IActionResult SignOut()
        //{
        //    return Ok();
        //}
    }
}

