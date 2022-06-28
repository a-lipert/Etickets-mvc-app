using etickets_web_app.Models;
using etickets_web_app.ViewModels;
using etickets_web_app.Data;


namespace etickets_web_app.Mappers
{
    public static class MovieViewModelMapper
    {
        public static Movie ToMovie (Movie movie, MovieViewModel movieViewModel)
        {
            movie.Id = movieViewModel.Id;
            movie.Name = movieViewModel.Name;
            movie.Description = movieViewModel.Description;
            movie.Price = movieViewModel.Price;
            movie.ImageURL = movieViewModel.ImageURL;
            movie.MovieCategorie = movieViewModel.movieCategorie;
            movie.StartDate = movieViewModel.StartDate;
            movie.EndDate = movieViewModel.EndDate;
            
            return movie;
        }
      
        public static MovieViewModel ToViewModel (Movie movie)
        {
            return new MovieViewModel();
        }
       
    }

}

