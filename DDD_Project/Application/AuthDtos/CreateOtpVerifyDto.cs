using System.ComponentModel.DataAnnotations;

namespace Application.AuthDtos
{
    public class CreateOtpVerifyDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "OTP is required.")]
        [Range(100000, 999999, ErrorMessage = "OTP must be a 6-digit number.")]
        public int OtpCode { get; set; }
    }
}