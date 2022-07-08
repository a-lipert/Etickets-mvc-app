using System.ComponentModel.DataAnnotations;

namespace etickets_web_app.Models
{
    public class OrderItem
    {
        [Key]
        public int Amount { get; set; }
        public double Price { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
