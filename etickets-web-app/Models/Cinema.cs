using etickets_web_app.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace etickets_web_app.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }  
    }
}
