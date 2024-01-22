using Test_It_trends1.Models;

namespace Test_It_trends1.ViewModels;

public class AuthorsIndexViewModel
{
    public List<Author> Authors { get; }
    public AuthorsIndexViewModel(List<Author> author)
    {
        Authors = author;
    }
}


