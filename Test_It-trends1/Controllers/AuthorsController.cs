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
            return View();
        }

        public IActionResult ShowById()
        {
            int id = 1;
            Author author = _manager.GetAuthorByID(id);          
            return View(author);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> ShowAll()
        {
            return View(_manager.GetAuthors());
        }

        [HttpPost]
        public ActionResult<Author> AddNewAuthor(Author author) 
        {
            try
            {
                _manager.CreateAuthor(author);
                return Ok(author);
            }
            catch(ArgumentException)
            {
                return BadRequest();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}