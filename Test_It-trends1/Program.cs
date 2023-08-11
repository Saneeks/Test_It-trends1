// See https://aka.ms/new-console-template for more information
using Test_It_trends1;
using Test_It_trends1.Entities;

Console.WriteLine("Started");

using (var context = new Context()) // ВЫЗОВ КОНСТРУКТОРА???
{
    New new_post1 = new New // Создание новости 1
    {
        Title = "So hot in Sochi!",
        Text = "I need air second air conditioner ASAP.",
        Time = DateTimeOffset.Now.AddHours(-2),
        Views = 3
    };

    New new_post2 = new New // Создание новости 2
    {
        Title = "Should I eat ice?",
        Text = "Difinitely not. There is no talking about.",
        Time = DateTimeOffset.Now,
        Views = 3
    };

    context.News.Add(new_post1); // Добавление в ДБ, сохранение, лог
    context.News.Add(new_post2);
    context.SaveChanges();
    Console.WriteLine("Saved"); 

    var news = context.News.ToList(); // Вывод из дб в консоль
    Console.WriteLine("Список новостей");
    foreach (New x in news)
    {
        Console.WriteLine($"{x.Id}, {x.Title}, {x.Text}, {x.Time}, {x.Views}");
    }

}