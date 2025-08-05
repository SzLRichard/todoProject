using System.ComponentModel.DataAnnotations;
using todo.core.Models.Enums;

namespace todo.core.Models
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string? Description { get; set; }
        public Importance Importance { get; set; }
        public TodoStatus Status { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
