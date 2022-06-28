using etickets_web_app.Data.Services;
using etickets_web_app.Mappers;
using etickets_web_app.Models;
using etickets_web_app.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace etickets_web_app.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public object ActorViewModelMapper { get; private set; }

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }
        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create ([Bind("FullName, ProfilePictureURL, Bio")] ActorViewModel actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            var dbModel = new Actor { Id = actor.Id, FullName = actor.FullName, Bio = actor.Bio, ProfilePictureURL = actor.ProfilePictureURL };
            await _service.AddAsync(dbModel);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
       public async Task<IActionResult> Edit(int id)
        {
            
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] ActorViewModel actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            var actorFromDb = await _service.GetByIdAsync(id);
            await _service.UpdateAsync(id, actorFromDb);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/delete/1
        public async Task<IActionResult> Delete(int id)
        {

            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
