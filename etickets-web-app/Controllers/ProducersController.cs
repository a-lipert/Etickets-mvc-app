using etickets_web_app.Data.Services;
using etickets_web_app.Models;
using etickets_web_app.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace etickets_web_app.Controllers
{
    [Authorize]
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            
            _service = service;
        }
        public object ProducerViewModelMapper { get; private set; }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //GET: producers/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //GET: producers/create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] ProducerViewModel producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            var dbModel = new Producer { Id = producer.Id, FullName = producer.FullName, Bio = producer.Bio, ProfilePictureURL = producer.ProfilePictureURL };
            await _service.AddAsync(dbModel);
            return RedirectToAction(nameof(Index));

        }
        //GET: producers/edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] ProducerViewModel producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            var producerFromDb = await _service.GetByIdAsync(id);
            await _service.UpdateAsync(id, producerFromDb);
            return RedirectToAction(nameof(Index));
        }
        

        //GET: producers/delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
