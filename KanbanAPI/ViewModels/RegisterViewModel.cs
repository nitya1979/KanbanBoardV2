using System.ComponentModel.DataAnnotations;

namespace KanbanAPI.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Confirm password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}