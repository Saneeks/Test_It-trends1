using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test_It_trends1.Managers;
using Test_It_trends1.Models;

namespace Test_It_trends1.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorsManager _manager;

        public AuthorsController(AuthorsManager manager)
        {
            _manager = manager;
        }


        public IActionResult Index()
        {
            return View(_manager.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _manager.Create(author);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}