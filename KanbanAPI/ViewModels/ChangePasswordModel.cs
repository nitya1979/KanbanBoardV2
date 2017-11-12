namespace KanbanAPI.ViewModels
{
    public class ChangePasswordModel
    {
        public string NewPassword { get; set; }
        public string CurrentPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}