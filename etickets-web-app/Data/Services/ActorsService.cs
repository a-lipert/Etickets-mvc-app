using etickets_web_app.Data.Base;
using etickets_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace etickets_web_app.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
    } 
    
}
