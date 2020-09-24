using Microsoft.Data.Sqlite;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using QuizPrototype.Data.Models;
using System;
using System.IO;
using System.Reflection;

namespace QuizPrototype.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }

      public DbSet<UserTest> UserTest { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Topic> Topic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=sqlitedemo.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }





    }
}
