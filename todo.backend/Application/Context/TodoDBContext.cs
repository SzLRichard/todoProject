using Microsoft.EntityFrameworkCore;
using todo.core.Models;

namespace Application.Context
{
    public class TodoDBContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoDBContext(DbContextOptions<TodoDBContext> optionos):base(optionos) 
        {
        
        }
    }
}
