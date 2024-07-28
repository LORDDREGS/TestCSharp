using Microsoft.AspNetCore.Mvc;
using TestCSharp.Models;
using TestCSharp.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestCSharp.Controllers
{
    public class UserController : Controller
    {
        private readonly MongoDbService _mongoDbService;

        public UserController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        
        public async Task<IActionResult> Create()
        {
            var viewModel = new UserViewModel
            {
                Plants = await _mongoDbService.GetPlantsAsync(),
                Departments = await _mongoDbService.GetDepartmentsAsync(),
                Positions = await _mongoDbService.GetPositionsAsync()
            };
            return View(viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Plant = viewModel.Plant,
                    Department = viewModel.Department,
                    Position = viewModel.Position,
                    Email = viewModel.Email,
                    Lastname = viewModel.Lastname,
                    Firstname = viewModel.Firstname,
                    Middlename = viewModel.Middlename,
                    Password = viewModel.Password
                };

                await _mongoDbService.CreateUserAsync(user);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Plants = await _mongoDbService.GetPlantsAsync();
            viewModel.Departments = await _mongoDbService.GetDepartmentsAsync();
            viewModel.Positions = await _mongoDbService.GetPositionsAsync();
            return View(viewModel);
        }

        
        public async Task<IActionResult> Index()
        {
            var users = await _mongoDbService.GetUsersAsync();
            return View(users);
        }

        
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _mongoDbService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _mongoDbService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UserViewModel
            {
                Plants = await _mongoDbService.GetPlantsAsync(),
                Departments = await _mongoDbService.GetDepartmentsAsync(),
                Positions = await _mongoDbService.GetPositionsAsync(),
                Email = user.Email,
                Lastname = user.Lastname,
                Firstname = user.Firstname,
                Middlename = user.Middlename,
                Plant = user.Plant,
                Department = user.Department,
                Position = user.Position
            };

            return View(viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Id = viewModel.Id,
                    Plant = viewModel.Plant,
                    Department = viewModel.Department,
                    Position = viewModel.Position,
                    Email = viewModel.Email,
                    Lastname = viewModel.Lastname,
                    Firstname = viewModel.Firstname,
                    Middlename = viewModel.Middlename,
                    Password = viewModel.Password
                };

                await _mongoDbService.UpdateUserAsync(user);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Plants = await _mongoDbService.GetPlantsAsync();
            viewModel.Departments = await _mongoDbService.GetDepartmentsAsync();
            viewModel.Positions = await _mongoDbService.GetPositionsAsync();
            return View(viewModel);
        }

        
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _mongoDbService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _mongoDbService.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
