using etickets_web_app.Models;

namespace etickets_web_app.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task <Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);  
        Actor Update(int id, Actor newActor);
        void Delete(int id);
    }
}
