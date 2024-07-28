using Microsoft.AspNetCore.Mvc;
using TestCSharp.Models;
using TestCSharp.Services;
using System.Threading.Tasks;
using TestCSharp.ViewModels; 

namespace TestCSharp.Controllers
{
    public class PlantController : Controller
    {
        private readonly MongoDbService _mongoDbService;

        public PlantController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        // GET: Plant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlantViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var plant = new Plant
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Location = viewModel.Location
                };

                await _mongoDbService.CreatePlantAsync(plant);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: Plant/Index
        public async Task<IActionResult> Index()
        {
            var plants = await _mongoDbService.GetPlantsAsync();
            return View(plants);
        }

        // GET: Plant/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var plant = await _mongoDbService.GetPlantByIdAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            var viewModel = new PlantViewModel
            {
                Id = plant.Id,
                Name = plant.Name,
                Location = plant.Location
            };

            return View(viewModel);
        }
    }
}
