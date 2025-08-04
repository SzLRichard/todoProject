
using todo.core.Models.Enums;

namespace Application.DTOs
{
    public class UpdateTodoItemDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Importance Importance { get; set; }
        public TodoStatus Status { get; set; }
        public DateTime Deadline { get; set; }
    }
}
