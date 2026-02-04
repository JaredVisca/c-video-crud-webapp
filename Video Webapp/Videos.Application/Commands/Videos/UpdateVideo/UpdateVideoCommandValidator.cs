using FluentValidation;
using Videos.Domain.Entities;

namespace Videos.Application.Commands.Videos.UpdateVideo;

public class UpdateVideoCommandValidator : AbstractValidator<UpdateVideoCommand>
{
    public UpdateVideoCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Video.Id)} cannot be empty")
            .NotNull()
            .WithMessage($"{nameof(Video.Id)} cannot be null");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage($"{nameof(Video.Title)} cannot be empty")
            .MaximumLength(100)
            .WithMessage($"{nameof(Video.Title)} cannot exceed 100 characters.");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage($"{nameof(Video.Description)} cannot be empty")
            .MaximumLength(1000)
            .WithMessage($"{nameof(Video.Description)} cannot exceed 1000 characters.");
        
        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage($"{nameof(Video.Category)} cannot be empty")
            .MaximumLength(100)
            .WithMessage($"{nameof(Video.Category)} cannot exceed 100 characters.");
    }
}