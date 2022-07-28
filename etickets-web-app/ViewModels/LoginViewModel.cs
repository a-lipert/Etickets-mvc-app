using System.ComponentModel.DataAnnotations;

namespace etickets_web_app.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
