using Application.Auths.AuthDtos;
using Domain.Auths;

namespace Application.Auth_A
{
    public interface IAuthApplication
    {
        Task<string> Login(CreateLoginDto dto);
        Task<string> ForgetPassword(CreateForgetPasswordDto dto);
        Task<string> ChangePassword(CreateChangePasswordDto dto,string userId);
        Task<string> OtpVerify(CreateOtpVerifyDto dto);
    }
}
