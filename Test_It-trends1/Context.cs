using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_It_trends1.Entities;

namespace Test_It_trends1
{
    internal class Context : DbContext // Контекст БД
    {
        public Context() // Конструктор
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Конфигурация подключения к БД
        {
            optionsBuilder.UseSqlite("Data Source=ItTrends.db"); // Лучше брать из файла
        }

        public DbSet<New> News {get; set;} // ???
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
