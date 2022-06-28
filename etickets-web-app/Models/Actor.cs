using etickets_web_app.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace etickets_web_app.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        
        public ICollection<Actor_Movie> Actors_Movies { get; set; }
    }
}
 