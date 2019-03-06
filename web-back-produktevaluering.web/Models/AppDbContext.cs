using Microsoft.EntityFrameworkCore;

namespace web_back_produktevaluering.web.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=evaluering.db");
        }

        public DbSet<Evaluering> Evalueringer { get; set; }
    }
}