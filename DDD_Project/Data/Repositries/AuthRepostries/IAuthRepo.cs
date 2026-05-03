using Domain.Auths;
using Domain.Users;

namespace Data.Repositries.AuthRepostries
{
    public interface IAuthRepo
    {
        
        Task<User> GetByEmail(string requestEmail);
       
        Task<User?>Login(string userName, string password);
        Task<OtpVerify?> OtpVerify(string userName, int otp);
        Task CreateOtp(OtpVerify otpVerify);

    }
}
