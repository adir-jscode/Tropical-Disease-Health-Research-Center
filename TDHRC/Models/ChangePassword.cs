using System.ComponentModel.DataAnnotations;

namespace TDHRC.Models
{
    public class ChangePassword
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Old Password is required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }
    }
}
