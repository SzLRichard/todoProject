
using Application.DTOs;
using AutoMapper;
using todo.core.Models;
using todo.core.Models.Enums;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<TodoItem,GetTodoItemDTO>().ForMember(dest => dest.Name,opt=>opt.MapFrom(src=>src.Title));
            CreateMap<CreateTodoItemDTO, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Status,opt => opt.MapFrom(src=>TodoStatus.Todo));
            CreateMap<UpdateTodoItemDTO, TodoItem>();
        }

    }
}
