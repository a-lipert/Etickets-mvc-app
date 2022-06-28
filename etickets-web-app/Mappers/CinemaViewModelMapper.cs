using etickets_web_app.Models;
using etickets_web_app.ViewModels;

namespace etickets_web_app.Mappers
{
    public static class CinemaViewModelMapper
    {
        public static Cinema ToCinema(Cinema cinema, CinemaViewModel cinemaViewModel)
        {
            cinema.Id = cinemaViewModel.Id;
            cinema.Logo = cinemaViewModel.Logo;
            cinema.Name = cinemaViewModel.Name;
            cinema.Description = cinemaViewModel.Description;

            return cinema;
        }

        public static CinemaViewModel ToViewModel (Cinema cinema)
        {
            return new CinemaViewModel();
           
        }
    }
}
