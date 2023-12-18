// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Test_It_trends1.Managers;
using Test_It_trends1.Models;

Console.WriteLine("Started");

var builder = WebApplication.CreateBuilder(args); // Создается WebApplication Builder

builder.Services.AddControllersWithViews(); // Для контроллера
builder.Services.AddEndpointsApiExplorer(); // Для сваггера
builder.Services.AddSwaggerGen(); // Для сваггера

builder.Services.AddDbContext<Context>( //Настраивает контекст Configuraion по умолчанию указывает на appsettings.json
            options => options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"))  // GetConnectionString("sqlite") указывает на путь настроек в appsettings.json
             );
builder.Services.AddScoped<AuthorsManager>();
builder.Services.AddScoped<ArticlesManager>();
builder.Services.AddScoped<CommentsManager>();
builder.Services.AddScoped<CategoriesManager>();

var app = builder.Build(); // Когда основные настройки билдера закончены, "сохраняет" и "собирает" билдер, далее настраиваем билдер через переменную app

if (app.Environment.IsDevelopment()) // Если программа запущена в дебаге, то используем запускаем сваггер
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();    //Заставляет подключаться через https

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();      //Заставляет использовать авторизацию, сейчас не актуально

//app.MapControllers(); // Нужен для указания пути к контроллерам и прочему

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Articles}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope()) // Костыль для создания объекта контекста, потому что IDisposable
{
    var context = scope.ServiceProvider.GetService<Context>();

    //context.Database.EnsureDeleted(); //Пересоздаем бд
    //context.Database.EnsureCreated();



    if (!context.Articles.Any())
    {
        Category categoryFood = new Category
        {
            Name = "Еда"
        };
        Category categoryLife = new Category
        {
            Name = "Жизнь"
        };

        Author authorWinnie = new Author
        {
            Name = "Винни Пух"
        };
        Author authorWolf = new Author
        {
            Name = "Одинокий волк"
        };


        Article article1 = new Article // Создание новости 1
        {
            Title = "Советы от Пуха",
            Text = "Когда идешь за медом - главное, чтоб пчелы тебя не заметили. Если шар будет зеленый, они могут подумать, что это листик, и не заметят его. А если шар будет синий - они подумают, что это просто кусочек неба, и тоже ничего не заметят.",
            Time = DateTimeOffset.Now.AddHours(-72),
            Views = 156,

        };
        authorWinnie.Articles.Add(article1);
        categoryFood.Articles.Add(article1);

        article1.Comments.Add(new Comment { Time = DateTimeOffset.Now.AddHours(-72 + 1), Text = "Нестареющая классика." });
        article1.Comments.Add(new Comment { Time = DateTimeOffset.Now.AddHours(-72 + 2), Text = "Вот раньше мультфильмы делали, не то что сейчас!" });
        article1.Comments.Add(new Comment { Time = DateTimeOffset.Now.AddHours(-72 + 3), Text = "Автор идиот! Из-за него меня покусали пчёлы!" });
        article1.Comments.Add(new Comment { Time = DateTimeOffset.Now.AddHours(-72 + 4), Text = "Логично, но чтобы пчёлы тебя не заметили, нужно покрасить себя в зелёный, а не шар." });

        Article article2 = new Article // Создание новости 2
        {
            Title = "Размышления о пчёлах",
            Text = "Это - жжжжжж - неспроста! Зря никто жужжать не станет. Само дерево жужжать не может. Значит, тут кто-то жужжит. А зачем тебе жужжать, если ты - не пчела? По-моему, так!",
            Time = DateTimeOffset.Now.AddHours(-48),
            Views = 366
        };
        authorWinnie.Articles.Add(article2);
        categoryLife.Articles.Add(article2);

        article2.Comments.Add(new Comment { Time = DateTimeOffset.Now.AddHours(-48 + 1), Text = "Жжжжжжжж, нет, там нет пчел, жжжжж" });
        article2.Comments.Add(new Comment { Time = DateTimeOffset.Now.AddHours(-48 + 2), Text = "Жжжж, это просто ветер, жжжжж, не обращай внимание на жжжужжащие деревья, жжжжж" });

        Article article3 = new Article // Создание новости 3
        {
            Title = "Безумно, можно быть...",
            Text = "Безумно, можно быть первым. Безумно, можно через стены. Попасть туда, окунуться в даль, я так хочу туда...",
            Time = DateTimeOffset.Now.AddHours(-24),
            Views = 228
        };
        authorWolf.Articles.Add(article3);
        categoryLife.Articles.Add(article3);

        article3.Comments.Add(new Comment { Time = DateTimeOffset.Now.AddHours(-24 + 1), Text = "Ауф" });
        article3.Comments.Add(new Comment { Time = DateTimeOffset.Now.AddHours(-24 + 2), Text = "Волк волку волк, а брат брату барт" });

        Article article4 = new Article // Создание новости 4
        {
            Title = "My life - my rules",
            Text = "Если жить, то красиво. Если взгляд, то четкий. Если надеяться, то только на себя. Если любить, то всем сердцем",
            Time = DateTimeOffset.Now.AddHours(-2),
            Views = 45
        };
        authorWolf.Articles.Add(article4);
        categoryLife.Articles.Add(article4);

        article4.Comments.Add(new Comment { Time = DateTimeOffset.Now.AddHours(-1), Text = "Кто постит эту чушь?!" });


        context.Articles.Add(article1); // Добавление в ДБ, сохранение, лог
        context.Articles.Add(article2);
        context.Articles.Add(article3);
        context.Articles.Add(article4);

        context.Categories.Add(categoryFood);
        context.Categories.Add(categoryLife);

        context.Authors.Add(authorWinnie);
        context.Authors.Add(authorWolf);

        context.SaveChanges();
        Console.WriteLine("Saved");
    }




}



app.Run();  // Запускаем программу