using System.ComponentModel.DataAnnotations;

namespace Lms.Mvc.Models
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "Username or Email is required.")]
        [StringLength(255, ErrorMessage = "Username or Email cannot exceed 255 characters.")]
        public string Identifier { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        public string Password { get; set; }
    }
}
