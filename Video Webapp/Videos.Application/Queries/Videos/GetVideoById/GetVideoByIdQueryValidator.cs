using FluentValidation;
using Videos.Domain.Entities;

namespace Videos.Application.Queries.Videos.GetVideoById;

public class GetVideoByIdQueryValidator : AbstractValidator<GetVideoByIdQuery>
{
    public GetVideoByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Video.Id)} cannot be empty)")
            .NotNull()
            .WithMessage($"{nameof(Video.Id)} cannot be null");
    }
}