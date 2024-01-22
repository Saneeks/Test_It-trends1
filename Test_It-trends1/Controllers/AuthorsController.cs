using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test_It_trends1.Models;
using Test_It_trends1.ViewModels;

namespace Test_It_trends1.Controllers
{
    public class AuthorsController : Controller
    {
        Context db;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(ILogger<AuthorsController> logger, Context context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
<<<<<<< Updated upstream
=======
            return View(new AuthorsIndexViewModel(_manager.GetAll()));
        }

        public IActionResult Create()
        {
>>>>>>> Stashed changes
            return View();
        }

        public IActionResult ShowById()
        {
            int id = 1;
            Author author = db.Authors.FirstOrDefault(x => x.Id == id);           
            return View(author);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> ShowAll()
        {
            return View( await db.Authors.ToListAsync());
        }

        [HttpPost]
<<<<<<< Updated upstream
        public async Task<ActionResult<Author>> AddNewAuthor(Author author) 
        {
            if (author == null)
                return BadRequest();

            db.Authors.Add(author);
            await db.SaveChangesAsync();
            return Ok(author);
=======
        public IActionResult Create(AuthorCreateViewModel author)
        {
            if (ModelState.IsValid)
            {
                _manager.Create(new Author() { Name = author.Name });
                return RedirectToAction(nameof(Index));
            }
            return View();
>>>>>>> Stashed changes
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}