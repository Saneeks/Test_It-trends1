using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test_It_trends1.Models;

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
        public async Task<ActionResult<Author>> AddNewAuthor(Author author) 
        {
            if (author == null)
                return BadRequest();

            db.Authors.Add(author);
            await db.SaveChangesAsync();
            return Ok(author);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}