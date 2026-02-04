using FluentValidation;
using Videos.Domain.Entities;

namespace Videos.Application.Commands.Videos.CreateVideo;

public class CreateVideoCommandValidator : AbstractValidator<CreateVideoCommand>
{
    public CreateVideoCommandValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage($"{nameof(Video.Category)} cannot be empty.")
            .MaximumLength(30)
            .WithMessage($"{nameof(Video.Category)} cannot exceed 30 characters.");
        
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage($"{nameof(Video.Title)} cannot be empty.")
            .MaximumLength(100)
            .WithMessage($"{nameof(Video.Title)} cannot exceed 100 characters.");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage($"{nameof(Video.Description)} cannot be empty.")
            .MaximumLength(1000)
            .WithMessage($"{nameof(Video.Description)} cannot exceed 1000 characters.");
        
    }
}