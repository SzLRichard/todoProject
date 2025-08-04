
using todo.core.Models;

namespace todo.core.Interfaces
{
    public interface ITodoRepository
    {
        public TodoItem? getById(Guid id);
        public IEnumerable<TodoItem> GetAll();
        public TodoItem Create(TodoItem item);
        public bool Delete(Guid id);
        public bool Update(TodoItem item);



    }
}
