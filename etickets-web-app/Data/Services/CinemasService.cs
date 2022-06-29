using etickets_web_app.Data.Base;
using etickets_web_app.Models;

namespace etickets_web_app.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}
