﻿using Microsoft.AspNetCore.Mvc;
<<<<<<< Updated upstream
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
=======
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;
using Test_It_trends1.Managers;
>>>>>>> Stashed changes
using Test_It_trends1.Models;
using Microsoft.EntityFrameworkCore;

namespace Test_It_trends1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")] // Путь будет .../api/Названия контроллера (Articles)/Название метода ()/Передаваемый атрибут
    public class ArticlesController : ControllerBase
    {
        Context db;
        public ArticlesController(Context context) // Тут создаётся контекст и срабатывает конструктор контекста
        {
<<<<<<< Updated upstream
            db = context;
=======
            _manager = manager;
            _authorsManager = authorsManager;
            _commentsManager = commentsManager;
            _categoriesManager = categoriesManager;
        }

        public IActionResult Index()
        {
            return View(new ArticlesIndexViewModel(_manager.GetAll()));
        }
        public IActionResult Create()
        {
            return View(new ArticlesCreateViewModel()
            {
                Authors = _authorsManager.GetAll(),
                Categories = _categoriesManager.GetAll(),
            });
>>>>>>> Stashed changes
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()  // async - значит в методе должен быть await
        {
            return await db.Articles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetTheArticle(int id) 
        {
            Article article = await db.Articles.FirstOrDefaultAsync(x => x.Id == id); 
            if (article == null)
                return NotFound();
            return new ObjectResult(article);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Post(Article article) //async должен возвращать Task. ActionResult дожен вернуть код состояния HTTP
        {
            if (article == null)
                return BadRequest();

            db.Articles.Add(article);
            await db.SaveChangesAsync();
            return Ok(article);
        }

        [HttpPut]
        public async Task<ActionResult<Article>> Put (Article article) // ActionResult<Article> дополнительно даёт возможность вернуть article
        {
<<<<<<< Updated upstream
            if (article == null)
                return BadRequest();    // код 400
            if (!db.Articles.Any(x => x.Id == article.Id)) // (x => x.Id == id); В x поочередно записываются объекты которые перебирает Any()
                return NotFound();      // код 404
            db.Update(article);
            await db.SaveChangesAsync();
            return Ok(article);         // код 200
        }
=======
            var article = _manager.GetByID(id);
            var comments = _commentsManager.GetComments(id, true);
            return View(new ArticlesDetailsViewModel(article, comments));
        }

>>>>>>> Stashed changes

        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> Delete(int id)
        {
            Article article = db.Articles.FirstOrDefault(x => x.Id == id); 
            if (article == null)
                return NotFound();
            db.Articles.Remove(article);
            await db.SaveChangesAsync();
            return Ok(article);
        }
        
    }
}
