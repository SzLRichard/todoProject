using todo.core.models;
using todo.core.models.enums;

var todoItem = new TodoItem()
{
    Id = Guid.NewGuid(),
    Title = "Test",
    CreatedAt = DateTime.UtcNow,
    Importance = Importance.NotImportant
};
