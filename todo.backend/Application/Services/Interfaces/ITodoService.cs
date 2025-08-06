
using Application.DTOs;
using todo.core.Models;

namespace Application.Services.Interfaces
{
    public interface ITodoService
    {
        public GetTodoItemDTO? GetById(Guid id);
        public IEnumerable<GetTodoItemDTO> GetAll();
        public GetTodoItemDTO Create(CreateTodoItemDTO dto);
        public DeleteResponseDTO Delete(Guid id);
        public UpdateResponseDTO Update(Guid id, UpdateTodoItemDTO dto);
        public Task<GetTodoItemDTO?> GetByIdAsync(Guid id);
        public Task<IEnumerable<GetTodoItemDTO>> GetAllAsync();
        public Task<GetTodoItemDTO> CreateAsync(CreateTodoItemDTO dto);
        public Task<DeleteResponseDTO> DeleteAsync(Guid id);
        public Task<UpdateResponseDTO> UpdateAsync(Guid id, UpdateTodoItemDTO dto);
    }
}
