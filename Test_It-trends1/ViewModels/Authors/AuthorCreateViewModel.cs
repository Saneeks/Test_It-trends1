using System.ComponentModel.DataAnnotations;
using Test_It_trends1.Models;

namespace Test_It_trends1.ViewModels;

public class AuthorCreateViewModel
{
    [Display(Name = "Введите имя автора")]
    [Required(ErrorMessage = "Имя введенно некорректно")]
    public string Name { get; set; }
}

