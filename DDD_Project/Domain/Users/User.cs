using System.ComponentModel.DataAnnotations;

namespace Domain.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsVerified { get; set; }
    }
}
