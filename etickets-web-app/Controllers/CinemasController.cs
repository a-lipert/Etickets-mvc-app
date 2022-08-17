using etickets_web_app.Data.Services;
using etickets_web_app.Models;
using etickets_web_app.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace etickets_web_app.Controllers
{
    [Authorize]
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public object CinemaViewModelMapper { get; set; }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        //GET: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] CinemaViewModel cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            var dbModel = new Cinema { Id = cinema.Id, Name = cinema.Name, Logo = cinema.Logo, Description = cinema.Description };
            await _service.AddAsync(dbModel);
            return RedirectToAction(nameof(Index));
        }

        //GET: Cinemas/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }
        //GET: Cinemas/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] CinemaViewModel cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            var dbModel = new Cinema { Id = cinema.Id, Name = cinema.Name, Logo = cinema.Logo, Description = cinema.Description };
            await _service.UpdateAsync(id, dbModel);
            return RedirectToAction(nameof(Index));
        }
        //GET: Cinemas/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaFromDb = await _service.GetByIdAsync(id);
            if (cinemaFromDb == null)
            {
                return View("NotFound");
            }
            return View(cinemaFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var cinemaFromDb = await _service.GetByIdAsync(id);
            if (cinemaFromDb == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }


    }
}

