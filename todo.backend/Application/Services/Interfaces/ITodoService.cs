
using Application.DTOs;
using todo.core.Models;

namespace Application.Services.Interfaces
{
    public interface ITodoService
    {
        public GetTodoItemDTO? GetById(Guid id);
        public IEnumerable<GetTodoItemDTO> GetAll();
        public GetTodoItemDTO Create(CreateTodoItemDTO dto);
        public bool Delete(Guid id);
        public bool Update(Guid id, UpdateTodoItemDTO dto);
    }
}
