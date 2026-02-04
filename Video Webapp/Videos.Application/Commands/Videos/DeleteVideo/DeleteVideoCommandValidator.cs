using FluentValidation;
using Videos.Domain.Entities;

namespace Videos.Application.Commands.Videos.DeleteVideo;

public class DeleteVideoCommandValidator : AbstractValidator<DeleteVideoCommand>
{
    public DeleteVideoCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Video.Id)} cannot be empty)")
            .NotNull()
            .WithMessage($"{nameof(Video.Id)} cannot be null");
    }
}