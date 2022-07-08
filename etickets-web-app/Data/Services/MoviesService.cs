using etickets_web_app.Data.Base;
using etickets_web_app.Models;
using etickets_web_app.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace etickets_web_app.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(MovieViewModel data)
        {

            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
            };

            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors -> joining entity

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId,
                };

                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<MovieDropdownViewModel> GetMovieDropdownValues()
        {
            var response = new MovieDropdownViewModel();
            response.Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync();
            response.Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync();
            response.Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync();

            return response;

        }

        public async Task UpdateMovieAsync(MovieViewModel data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategorie = data.movieCategorie;
                await _context.SaveChangesAsync();
            }
            //Remove existing actors

            var existingActorsDb = _context.Actor_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actor_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();


            //Add Movie Actors -> joining entity

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId,
                };

                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

        }
    }
}