using System.ComponentModel.DataAnnotations;

namespace Application.AuthDtos
{
    public class CreateForgetPasswordDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string EmailId { get; set; }
    }
}