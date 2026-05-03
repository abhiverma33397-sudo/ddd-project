using Domain.Auths;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        { }

        public DbSet<User> Users { get; set; }
        
        public DbSet<OtpVerify> OtpVerifies { get; set; }
        
    }
    
    
}
