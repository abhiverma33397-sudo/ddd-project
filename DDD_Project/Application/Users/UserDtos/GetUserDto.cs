using System.ComponentModel.DataAnnotations;

namespace Application.Users.UserDtos
{
    public class GetUserDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }
    }
}