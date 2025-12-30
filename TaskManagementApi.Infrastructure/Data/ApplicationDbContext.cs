using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Core.Models;
namespace TaskManagementApi.Infrastructure.Data;
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TodoTask> TodoTask {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entiry<TodoTask>(entity => {
                        entity.HasKey(e => e.Id);
                        entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                        entity.Property(e => e.Description).HasMaxLength(1000);
                        entity.Property(e => e.Priority).HasConversion<string>();
                    });
        }
    }
}

