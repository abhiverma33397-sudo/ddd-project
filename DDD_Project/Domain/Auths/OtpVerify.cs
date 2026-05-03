using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Auths
{
    public class OtpVerify
    {
        public int Id { get; set; }
       public  string UserName { get; set; }
        public int OtpCode { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime ExpireTime { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }



    }
}
