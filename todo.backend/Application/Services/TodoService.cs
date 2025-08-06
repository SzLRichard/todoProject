using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using FluentValidation;
using todo.core.Interfaces;
using todo.core.Models;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        private readonly IMapper _mapper;

        private readonly IValidator<CreateTodoItemDTO> _createValidator;
        private readonly IValidator<UpdateTodoItemDTO> _updateValidator;


        public TodoService(ITodoRepository repository, IMapper mapper, IValidator<CreateTodoItemDTO> createValidator, IValidator<UpdateTodoItemDTO> updateValidator) { 
            _repository = repository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public GetTodoItemDTO Create(CreateTodoItemDTO dto)
        {
            _createValidator.ValidateAndThrow(dto);
            var newItem = _mapper.Map<TodoItem>(dto);
            var createdTodo = _repository.Create(newItem);
            return _mapper.Map<GetTodoItemDTO>(createdTodo);
            
        }

        public async Task<GetTodoItemDTO> CreateAsync(CreateTodoItemDTO dto)
        {
            await _createValidator.ValidateAndThrowAsync(dto);
            var newItem = _mapper.Map<TodoItem>(dto);
            var createdTodo = await _repository.CreateAsync(newItem);
            return _mapper.Map<GetTodoItemDTO>(createdTodo);
        }

        public DeleteResponseDTO Delete(Guid id)
        {
            return new DeleteResponseDTO(_repository.Delete(id));
        }

        public async Task<DeleteResponseDTO> DeleteAsync(Guid id)
        {
            return new DeleteResponseDTO( await _repository.DeleteAsync(id));
        }

        public IEnumerable<GetTodoItemDTO> GetAll()
        {
            var todos = _repository.GetAll();
            return _mapper.Map<IEnumerable<GetTodoItemDTO>>(todos);
        }

        public async Task<IEnumerable<GetTodoItemDTO>> GetAllAsync()
        {
            var todos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetTodoItemDTO>>(todos);
        }

        public GetTodoItemDTO? GetById(Guid id)
        {
           var todoItem = _repository.getById(id);
            if (todoItem == null) {
                return null;
            }
            return _mapper.Map<GetTodoItemDTO>(todoItem);
        }

        public async Task<GetTodoItemDTO?> GetByIdAsync(Guid id)
        {
            var todoItem = await _repository.getByIdAsync(id);
            if (todoItem == null)
            {
                return null;
            }
            return _mapper.Map<GetTodoItemDTO>(todoItem);
        }

        public UpdateResponseDTO Update(Guid id, UpdateTodoItemDTO dto)
        {
            _updateValidator.ValidateAndThrow(dto);
            var newTodoItem = _mapper.Map<TodoItem>(dto);
            newTodoItem.Id=id;
            return new UpdateResponseDTO(_repository.Update(newTodoItem));
        }

        public async Task<UpdateResponseDTO> UpdateAsync(Guid id, UpdateTodoItemDTO dto)
        {
            await _updateValidator.ValidateAndThrowAsync(dto);
            var newTodoItem = _mapper.Map<TodoItem>(dto);
            newTodoItem.Id = id;
            return new UpdateResponseDTO(await _repository.UpdateAsync(newTodoItem));
        }
    }
}
