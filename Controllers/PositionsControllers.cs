using Microsoft.AspNetCore.Mvc;
using TestCSharp.Models;
using TestCSharp.Services;
using System.Threading.Tasks;
using TestCSharp.ViewModels; // Убедитесь, что это правильное пространство имен

namespace TestCSharp.Controllers
{
    public class PositionController : Controller
    {
        private readonly MongoDbService _mongoDbService;

        public PositionController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        // GET: Position/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new PositionViewModel
            {
                Plants = await _mongoDbService.GetPlantsAsync()
            };
            return View(viewModel);
        }

        // POST: Position/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PositionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var position = new Position
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    Plant = viewModel.PlantId
                };

                await _mongoDbService.CreatePositionAsync(position);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Plants = await _mongoDbService.GetPlantsAsync();
            return View(viewModel);
        }

        // GET: Position/Index
        public async Task<IActionResult> Index()
        {
            var positions = await _mongoDbService.GetPositionsAsync();
            return View(positions);
        }

        // GET: Position/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var position = await _mongoDbService.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            var viewModel = new PositionViewModel
            {
                Id = position.Id,
                Name = position.Name,
                Description = position.Description,
                PlantId = position.Plant,
                Plants = await _mongoDbService.GetPlantsAsync()
            };

            return View(viewModel);
        }
    }
}
