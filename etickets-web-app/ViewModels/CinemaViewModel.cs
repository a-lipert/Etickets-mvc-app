using System.ComponentModel.DataAnnotations;

namespace etickets_web_app.ViewModels
{
    public class CinemaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
