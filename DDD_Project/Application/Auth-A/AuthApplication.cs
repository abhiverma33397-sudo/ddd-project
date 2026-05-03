using Application.AuthDtos;
using Application.Services.MailServices;
using Application.Services.TokenServices;
using Data.DataContexts;
using Data.Repositries.AuthRepostries;
using Data.Repositries.UserRepo;
using Domain.Auths;
using Microsoft.EntityFrameworkCore;


namespace Application.Auth_A
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IAuthRepo _authRepo;
        private readonly ITokenGenerate _tokenGenerate;
        private readonly IMailService _mailService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserRepo _userRepo;
        public AuthApplication(IAuthRepo authRepo, ITokenGenerate tokenGenerate,
            IMailService mailService,
            ApplicationDbContext dbContext, IUserRepo userRepo)
        {
            _authRepo = authRepo;
            _tokenGenerate = tokenGenerate;
            _mailService = mailService;
            _dbContext = dbContext;
            _userRepo = userRepo;
        }

        public async Task<string> Login(CreateLoginDto dto)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x =>
                    x.UserName == dto.UserName &&
                    x.Password == dto.Password);

            if (user == null)
                return "Invalid email or password.";

            if (!user.IsVerified)
                return "Please verify your email using OTP before login.";

            return _tokenGenerate.GenerateToken(
                user.Role,
                user.Id
            );
        }
        public async Task<string> ForgetPassword(CreateForgetPasswordDto dto)
        {
            var user = await _authRepo.GetByEmail(dto.EmailId);

            if (user == null)
                return "User not found.";

            var otp = new Random().Next(100000, 999999);

           
            var otpverify = new OtpVerify
            {
                UserName = user.UserName.Trim().ToLower(),
                OtpCode = otp,
                CreatedAt = DateTime.UtcNow,
                ExpireTime = DateTime.UtcNow.AddMinutes(5),
                UserId = user.Id
            };

            await _authRepo.CreateOtp(otpverify);

          
            var mailmessage = new MailMessage
            {
                To = user.UserName,
                Subject = "OTP for Password Reset",
                Body = $"Your OTP is: {otp}. It will expire in 5 minutes."
            };

            await _mailService.SendMail(mailmessage);

            return "OTP sent successfully.";
        }
        public async Task<string> OtpVerify(CreateOtpVerifyDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName))
                return "Email is required.";

            if (dto.OtpCode <= 0)
                return "OTP is required.";

            var email = dto.UserName.Trim().ToLower();

            var otpRecord = await _authRepo.OtpVerify(email, dto.OtpCode);

            if (otpRecord == null)
                return "Invalid OTP.";

            if (otpRecord.ExpireTime < DateTime.UtcNow)
                return "OTP has expired.";

            if (otpRecord.User == null)
                return "User not found.";

            var token = _tokenGenerate.GenerateToken(
                otpRecord.User.Role,
                otpRecord.User.Id
            );

            return token;
        }
        public async Task<string> ChangePassword(CreateChangePasswordDto dto, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return "Invalid user session.";

            if (dto.OldPassword == null || dto.NewPassword == null)
                return "Old and New password required.";

            if (dto.NewPassword != dto.ConfirmPassword)
                return "Password mismatch.";

            if (!int.TryParse(userId, out int id))
                return "Invalid token user.";

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return "User not found.";

            if (user.Password != dto.OldPassword)
                return "Old password incorrect.";

            if (dto.NewPassword == dto.OldPassword)
                return "New password cannot be same.";

            user.Password = dto.NewPassword;

            await _dbContext.SaveChangesAsync();   

            return "Password changed successfully.";
        }
    }

}
