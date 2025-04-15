using Microsoft.AspNetCore.Identity;
using SmartStore.Domain.DTOs.Request.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Core.Services.Shared.Abstraction
{
    public interface IIdentityService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto changePasswordDto);
        Task<IdentityResult> SendPasswordResetEmailAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto model);
    }
}
