using Microsoft.AspNetCore.Mvc;
using TestCSharp.Models;
using TestCSharp.Services;
using System.Threading.Tasks;
using TestCSharp.ViewModels; 
namespace TestCSharp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MongoDbService _mongoDbService;

        public DepartmentController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        // GET: Department/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new DepartmentViewModel
            {
                Plants = await _mongoDbService.GetPlantsAsync()
            };
            return View(viewModel);
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    ShortName = viewModel.ShortName,
                    IsAuditor = viewModel.IsAuditor,
                    Plant = viewModel.PlantId
                };

                await _mongoDbService.CreateDepartmentAsync(department);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Plants = await _mongoDbService.GetPlantsAsync();
            return View(viewModel);
        }

        // GET: Department/Index
        public async Task<IActionResult> Index()
        {
            var departments = await _mongoDbService.GetDepartmentsAsync();
            return View(departments);
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var department = await _mongoDbService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            var viewModel = new DepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                ShortName = department.ShortName,
                IsAuditor = department.IsAuditor,
                PlantId = department.Plant,
                Plants = await _mongoDbService.GetPlantsAsync()
            };

            return View(viewModel);
        }
    }
}
