using etickets_web_app.Data;
using etickets_web_app.Data.Services;
using etickets_web_app.Models;
using etickets_web_app.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etickets_web_app.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
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
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]CinemaViewModel cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            var dbModel = new Cinema { Id = cinema.Id, Name = cinema.Name, Logo = cinema.Logo, Description = cinema.Description };
            await _service.AddAsync(dbModel);
            return RedirectToAction(nameof(Index));
        }
            
    }
}

