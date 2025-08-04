
using Application.Context;
using Microsoft.EntityFrameworkCore;
using todo.core.Interfaces;
using todo.core.Models;

namespace Infrastructure.Persistence.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IDbContextFactory<TodoDBContext> _dbContextFactory;

        public TodoRepository(IDbContextFactory<TodoDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        
        public TodoItem Create(TodoItem item)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.TodoItems.Add(item);
            context.SaveChanges();
            return item;
        }

        public bool Delete(Guid id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var todoItem = context.TodoItems.Find(id);
            if(todoItem==null)
            {
                return false;
            }
            context.Remove(todoItem);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.TodoItems.AsNoTracking().ToList();
        }

        public TodoItem? getById(Guid id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.TodoItems.AsNoTracking().FirstOrDefault(todo => todo.Id==id);
        }

        public bool Update(TodoItem item)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var updated = context.TodoItems.Update(item);
            if (updated == null) 
            {
                return false;
            }
            context.SaveChanges();
            return true;
        }
    }
}
