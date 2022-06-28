using ApiBliss.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBliss.Data
{
    public class ApiBlissContext : DbContext
    {
        public ApiBlissContext(DbContextOptions<ApiBlissContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
    }
}
