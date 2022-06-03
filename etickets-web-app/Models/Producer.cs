using System.ComponentModel.DataAnnotations;

namespace etickets_web_app.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
