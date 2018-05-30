using System.ComponentModel.DataAnnotations;

namespace KanbanAPI.ViewModels
{
    public class ChangePasswordModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Current Password is required")]
        public string CurrentPassword { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        public string NewPassword { get; set; }
        
		[Required(AllowEmptyStrings = false, ErrorMessage = "Confirm password is required")]
        [Compare("NewPassword", ErrorMessage = "Confirm Password is no matching")]
        public string ConfirmPassword { get; set; }
    }
}