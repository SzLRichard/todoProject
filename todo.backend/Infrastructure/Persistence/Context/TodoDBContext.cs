using Microsoft.EntityFrameworkCore;
using todo.core.Models;

namespace Infrastructure.Persistence.Context
{
    public class TodoDBContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoDBContext(DbContextOptions<TodoDBContext> optionos):base(optionos) 
        {
        
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoItem>().HasKey(t => t.Id);
            modelBuilder.Entity<TodoItem>().Property(t => t.Title).IsRequired().HasMaxLength(100);
        }
    }
}
