using etickets_web_app.Data;
using System.ComponentModel.DataAnnotations;

namespace etickets_web_app.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public MovieCategorie MovieCategorie { get; set; }
        
        
    }
}
