using Application.Services.MailServices;
using Application.UserDtos;
using AutoMapper;
using Data.Repositries.AuthRepostries;
using Data.Repositries.UserRepo;
using Domain.Auths;
using Domain.Users;

namespace Application.Users
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepo _userRepo;
        private readonly IMailService _mailService;
        private readonly IAuthRepo _authRepo;
        private readonly IMapper _mapper;

        public UserApplication(IUserRepo userRepo, IMailService mailService, IAuthRepo authRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mailService = mailService;
            _authRepo = authRepo;
            _mapper = mapper;
        }

        public async Task<string> Create(UserCreateDto dto)
        {
            var email = dto.UserName.Trim().ToLower();

            var existingUser = await _authRepo.GetByEmail(email);

            if (existingUser != null)
                return "User already exists with this email.";


            User user = _mapper.Map<User>(dto);
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
            var result = _mapper.Map<List<GetUserDto>>(users);
            
            return result;
        }

        public async Task<GetUserDto> GetById(int id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
                return null;
            var result = _mapper.Map<GetUserDto>(user);

            return result;
        }

        public async Task Update(int id, UserUpdateDto dto)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _mapper.Map(dto, user);
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

