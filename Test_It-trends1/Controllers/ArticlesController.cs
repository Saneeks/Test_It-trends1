using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test_It_trends1.Managers;
using Test_It_trends1.Models;
using Test_It_trends1.ViewModels;

namespace Test_It_trends1.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ArticlesManager _manager;
        private readonly AuthorsManager _authorsManager;
        private readonly CommentsManager _commentsManager;
        private readonly CategoriesManager _categoriesManager;

        public ArticlesController(
            ArticlesManager manager,
            AuthorsManager authorsManager,
            CommentsManager commentsManager,
            CategoriesManager categoriesManager)
        {
            _manager = manager;
            _authorsManager = authorsManager;
            _commentsManager = commentsManager;
            _categoriesManager = categoriesManager;
        }

        public IActionResult Index()
        {
            return View(_manager.GetAll());
        }
        public IActionResult Create()
        {
            return View(new ArticlesCreateViewModel()
            {
                Authors = _authorsManager.GetAll(),
                Categories = _categoriesManager.GetAll(),
            });
            
        }
        [HttpPost]
        public IActionResult Create(ArticlesCreateViewModel article)
        {
            try
            {
                _manager.Create(article.Title, article.Text, article.CategoryId, article.AuthorId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Create));
            }
        }

        public IActionResult Details(int id) 
        {
            var article = _manager.GetByID(id);
            var comments = _commentsManager.GetComments(id, true);
            return View(new ArticlesDetailsViewModel(article, comments));
        }
        [HttpPost]
        public IActionResult CreateComment(ArticlesDetailsViewModel article)
        {
            //if (!ModelState.IsValid)
            //   return Redirect("/Articles/Details/"+article.Id);
            try
            {
                _commentsManager.Create(article.Id, article.NewCommentText);
                return Redirect("/Articles/Details/" + article.Id);
            }
            catch (Exception)
            {
                return Redirect("/Articles/Details/" + article.Id);
            }
        }

        public IActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}