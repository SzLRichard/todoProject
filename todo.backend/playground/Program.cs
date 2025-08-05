using todo.core.Models;
using todo.core.Models.Enums;

var todoItem = new TodoItem()
{
    Id = Guid.NewGuid(),
    Title = "Test",
    CreatedAt = DateTime.UtcNow,
    Importance = Importance.NotImportant
};
