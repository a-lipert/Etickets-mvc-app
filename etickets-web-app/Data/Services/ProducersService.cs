using etickets_web_app.Data.Base;
using etickets_web_app.Models;

namespace etickets_web_app.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)   
        {
        }
    }
}
