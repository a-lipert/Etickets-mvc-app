using etickets_web_app.Models;
using etickets_web_app.ViewModels;

namespace etickets_web_app.Mappers
{
    public static class ActorViewModelMapper
    {
        public static Actor ToActor(Actor actor, ActorViewModel viewModel)
        {
            actor.FullName = viewModel.FullName;
            actor.ProfilePictureURL = viewModel.ProfilePictureURL;
            actor.Bio = viewModel.Bio;
              
            return actor;

        }

        public static ActorViewModel ToViewModel(Actor actor)
        {
            return new ActorViewModel
            {
                FullName = actor.FullName,
                ProfilePictureURL = actor.ProfilePictureURL,
                Bio = actor.Bio,
            };
        }

     
    }
}
