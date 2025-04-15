using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStore.Core.Services.Shared.Abstraction;
using SmartStore.Domain.DTOs.Request.Security;

namespace SmartStore.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _identityService.RegisterAsync(registerDto);
            if (result.Succeeded)
                return Ok(new { Message = "User registered successfully" });

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _identityService.LoginAsync(loginDto);
            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(new { Token = token });
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var result = await _identityService.ChangePasswordAsync(changePasswordDto);
            if (result.Succeeded)
                return Ok(new { Message = "Password changed successfully" });

            return BadRequest(result.Errors);
        }

        [HttpPost("send-password-reset-email")]
        public async Task<IActionResult> SendPasswordResetEmail([FromBody] string email)
        {
            var result = await _identityService.SendPasswordResetEmailAsync(email);
            if (result.Succeeded)
                return Ok(new { Message = "Password reset email sent" });

            return BadRequest(result.Errors);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var result = await _identityService.ResetPasswordAsync(resetPasswordDto);
            if (result.Succeeded)
                return Ok(new { Message = "Password reset successful" });

            return BadRequest(result.Errors);
        }
    }
}
