using Microsoft.EntityFrameworkCore;

namespace web_back_produktevaluering.web.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Evaluering> Evalueringer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database/evaluering.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evaluering>(entity =>
            {
                entity.HasKey(e => e.EvalueringId);
                entity.Property(e => e.Oprettet).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}