using Microsoft.EntityFrameworkCore;
using QuizPrototype.Data.Models;

namespace QuizPrototype.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=quizes;Trusted_Connection=True;");
        }

    }
}
