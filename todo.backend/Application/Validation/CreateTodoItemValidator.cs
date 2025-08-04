
using Application.DTOs;
using FluentValidation;

namespace Application.Validation
{
    public class CreateTodoItemValidator : AbstractValidator<CreateTodoItemDTO>
    {
        public CreateTodoItemValidator()
        {
            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Title cannot be empty")
                .MaximumLength(100).WithMessage("Title cannot contain more than 100 characters");
            RuleFor(dto => dto.Description)
                .MaximumLength(500).WithMessage("Description cannot contain more than 500 characters");
            RuleFor(dto => dto.Deadline)
                .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Deadline must be a future date");
        }

    }
}
