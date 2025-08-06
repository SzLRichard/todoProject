
using System.ComponentModel.DataAnnotations;
using todo.core.Models.Enums;

namespace Application.DTOs
{
    public class CreateTodoItemDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public Importance Importance { get; set; } = Importance.NotImportant;
    }
}
