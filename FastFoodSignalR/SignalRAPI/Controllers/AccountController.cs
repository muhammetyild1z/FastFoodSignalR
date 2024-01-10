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
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("SignIn")]
        public IActionResult SignIn()
        {
            return Ok();
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            if (signUpDto.Password==signUpDto.PasswordConfirm)
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

