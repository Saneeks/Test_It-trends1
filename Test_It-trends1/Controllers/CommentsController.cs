using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_It_trends1.Managers;
using Test_It_trends1.ViewModels;

namespace Test_It_trends1.Controllers
{
    public class CommentsController : Controller
    {   
        private readonly CommentsManager _manager;
        public CommentsController (CommentsManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public IActionResult Create(ArticlesDetailsViewModel article)
        {
            try
            {
                _manager.Create(article.Id, article.NewCommentText);
                return RedirectToAction("Details", "Articles", new { article.Id });
            }
            catch (Exception)
            {
                return RedirectToAction("Details", "Articles", new { article.Id });
            }
        }
    }
}
