using Data.DataContexts;
using Domain.Auths;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositries.AuthRepostries
{
    public class AuthRepo : IAuthRepo
    {
        private readonly ApplicationDbContext _context;


        public AuthRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<User> GetByEmail(string requestEmail)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.UserName == requestEmail);
        }

        public async Task<User?> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);

            return user;
        }


        public async Task<OtpVerify?> OtpVerify(string emailId, int otpCode)
        {
            emailId = emailId.Trim().ToLower();

            return await _context.OtpVerifies
                .Include(x => x.User)
                .Where(x => x.UserName.ToLower() == emailId)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(x => x.OtpCode == otpCode);
        }
        public async Task CreateOtp(OtpVerify otpVerify)
        {
            await _context.OtpVerifies.AddAsync(otpVerify);
            await _context.SaveChangesAsync();
        }


    }
}
