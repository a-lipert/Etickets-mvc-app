using etickets_web_app.Data.Base;
using etickets_web_app.Models;
using etickets_web_app.ViewModels;

namespace etickets_web_app.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync (int id);
        Task<MovieDropdownViewModel> GetMovieDropdownValues();
        Task AddNewMovieAsync(MovieViewModel data);
        Task UpdateMovieAsync(MovieViewModel data);
    }
}
