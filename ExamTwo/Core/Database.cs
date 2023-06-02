using Microsoft.EntityFrameworkCore;
using Examtwo.Models;

namespace Examtwo.Core
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }

        public DbSet<ExamtwoClass> Exams => Set<ExamtwoClass>();

        public void Seed()
        {
            AddProducts();
        }

        private void AddProducts()
        {
            Exams.Add(new ExamtwoClass
            {
                Name = "Lucas",
                Price = 2,
                Description = "bo",
                CreatedDate = DateTime.UtcNow
            });
            


            SaveChanges();
        }
    }
}