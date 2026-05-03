using Application.Services.MailServices;
using Application.UserDtos;
using Data.Repositries.AuthRepostries;
using Data.Repositries.UserRepo;
using Domain.Auths;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepo _userRepo;
        private readonly IMailService _mailService;
        private readonly IAuthRepo _authRepo;

        public UserApplication(IUserRepo userRepo, IMailService mailService, IAuthRepo authRepo)
        {
            _userRepo = userRepo;
            _mailService = mailService;
            _authRepo = authRepo;
        }

        public async Task<string> Create(CreateUpdateDto dto)
        {
            var email = dto.UserName.Trim().ToLower();

            var existingUser = await _authRepo.GetByEmail(email);

            if (existingUser != null)
                return "User already exists with this email.";

            var user = new User
            {
                FirstName = dto.FirstName.Trim(),
                LastName = dto.LastName.Trim(),
                UserName = email,
                Password = dto.Password,
                Role = dto.Role.Trim(),
                IsVerified = false
            };

            await _userRepo.Create(user);
            var otp = new Random().Next(100000, 999999);

            var otpEntity = new OtpVerify
            {
                UserId = user.Id,
                UserName = user.UserName,
                OtpCode = otp,
                CreatedAt = DateTime.UtcNow,
                ExpireTime = DateTime.UtcNow.AddMinutes(5)
            };

            await _authRepo.CreateOtp(otpEntity);

            var mailMessage = new MailMessage
            {
                To = user.UserName,
                Subject = "Email Verification OTP",
                Body = $@"
            <h2>Email Verification</h2>
            <p>Your OTP is:</p>
            <h1>{otp}</h1>
            <p>This OTP will expire in 5 minutes.</p>"
            };

            try
            {
                await _mailService.SendMail(mailMessage);
            }
            catch (Exception ex)
            {
                return $"User created, but OTP email failed: {ex.Message}";
            }

            return "Registration successful. Please verify your email using the OTP sent to your email.";
        }
        public async Task<List<GetUserDto>> GetAll()
        {
            var users = await _userRepo.GetAll();
            var result = users.Select(user => new GetUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Role = user.Role
            }).ToList();
            return result;
        }

        public async Task<GetUserDto> GetById(int id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
                return null;
            var result = new GetUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Role = user.Role
            };
            return result;
        }

        public async Task Update(int id, CreateUpdateDto dto)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.UserName = dto.UserName;
            user.Role = dto.Role;
            await _userRepo.Update(user);
        }
        public async Task Delete(int id)
        {
            var user = await _userRepo.GetById(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            await _userRepo.Delete(user);
        }
    }
}

