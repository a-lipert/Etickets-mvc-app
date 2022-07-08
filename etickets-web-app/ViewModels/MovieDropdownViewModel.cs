using etickets_web_app.Models;

namespace etickets_web_app.ViewModels
{
    public class MovieDropdownViewModel
    {
        public MovieDropdownViewModel()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();

        }
        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
