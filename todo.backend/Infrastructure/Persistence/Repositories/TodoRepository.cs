
using Infrastructure.Persistence.Context;
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
            if (todoItem == null)
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
            return context.TodoItems.AsNoTracking().FirstOrDefault(todo => todo.Id == id);
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

        public async Task<TodoItem> CreateAsync(TodoItem item)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.TodoItems.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var todoItem = await context.TodoItems.FindAsync(id);
            if(todoItem==null)
            {
                return false;
            }
            context.Remove(todoItem);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            return await context.TodoItems.AsNoTracking().ToListAsync();
        }

        public async Task<TodoItem?> getByIdAsync(Guid id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.TodoItems.AsNoTracking().FirstOrDefaultAsync(todo => todo.Id==id);
        }

        public async Task<bool> UpdateAsync(TodoItem item)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var updated = context.TodoItems.Update(item);
            if (updated == null) 
            {
                return false;
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
