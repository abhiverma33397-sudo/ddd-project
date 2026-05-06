using Application.Auth_A;
using Application.Auths.AuthDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAp_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApplication _authApplication;
        public AuthController(IAuthApplication authApplication)
        {
            _authApplication = authApplication;
        }


        [HttpPost("login")]
        public async Task<IActionResult> PostLogin(CreateLoginDto dto)
        {
            var result = await _authApplication.Login(dto);
            return Ok(result);
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> PostForgetPassword(CreateForgetPasswordDto dto)
        {
            var result = await _authApplication.ForgetPassword(dto);
            return Ok(result);
        }
        [HttpPost("otp-verify")]
        public async Task<IActionResult> PostOtpVerify(CreateOtpVerifyDto dto)
        {
            var result = await _authApplication.OtpVerify(dto);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(CreateChangePasswordDto dto)
        {
            var userId = User.FindFirst("UserId")?.Value;

            var result = await _authApplication.ChangePassword(dto, userId);

            return Ok(result);
        }
    }
}
