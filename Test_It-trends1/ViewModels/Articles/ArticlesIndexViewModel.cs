using System.ComponentModel.DataAnnotations;
using Test_It_trends1.Models;

namespace Test_It_trends1.ViewModels;

public class ArticlesIndexViewModel
{
    public List<Article> Articles { get; }
    public ArticlesIndexViewModel(List<Article> article)
    { 
        Articles = article;
    }


}

