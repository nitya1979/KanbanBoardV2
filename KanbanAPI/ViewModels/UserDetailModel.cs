

using System.ComponentModel.DataAnnotations;

namespace KanbanAPI.ViewModels
{
    public class UserDetailModel
    {
        //[Required(ErrorMessage ="Image Url is required")]
        public string ImageUrl { get; set; }

        public string PhoneNo { get; set; }

        public string AboutMe { get; set; }
    }
}
