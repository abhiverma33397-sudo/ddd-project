using Domain.Auths;
using Domain.Transactions;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<OtpVerify> OtpVerifies { get; set; }
        public DbSet<UserTransaction> Transactions { get; set; }
    }


}
