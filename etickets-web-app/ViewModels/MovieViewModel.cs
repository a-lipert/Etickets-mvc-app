using etickets_web_app.Data;
using etickets_web_app.Models;
using System.ComponentModel.DataAnnotations;

namespace etickets_web_app.ViewModels
{
    public class MovieViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Description = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        
        public string Name { get; set; }

        [Display(Description = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Description = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Display(Description = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Description = "Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTimeOffset StartDate { get; set; }


        [Display(Description = "End Date")]
        [Required(ErrorMessage = "End Date is required")]
        public DateTimeOffset EndDate { get; set; }


        [Display(Description = "Select a category")]
        [Required(ErrorMessage = "Movie Category is required")]
        public MovieCategorie movieCategorie { get; set; }

        //Relationships

        [Display(Description = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Description = "Select cinema")]
        [Required(ErrorMessage = "Cinema is required")]
        public int CinemaId { get; set; }
        public CinemaViewModel Cinema { get; set; }

        [Display(Description = "Select a producer")]
        [Required(ErrorMessage = "Movie producer is required")]
        public int ProducerId { get; set; }
        public ProducerViewModel Producer { get; set; }

        public ICollection<Actor_Movie> Actor_Movies { get; set; }

    }
}
