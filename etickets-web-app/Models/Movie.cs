using etickets_web_app.Data;
using etickets_web_app.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace etickets_web_app.Models
{
    public class Movie : IEntityBase
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
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Actor_Movie> Actor_Movies { get; set;}
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }


    }
}
