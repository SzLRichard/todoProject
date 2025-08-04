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

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<GetTodoItemDTO> GetAll()
        {
            var todos = _repository.GetAll();
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

        public bool Update(Guid id, UpdateTodoItemDTO dto)
        {
            _updateValidator.ValidateAndThrow(dto);
            var newTodoItem = _mapper.Map<TodoItem>(dto);
            newTodoItem.Id=id;
            return _repository.Update(newTodoItem);
        }
    }
}
