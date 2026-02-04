using MediatR;

namespace Videos.Application.Commands.Videos.DeleteVideo;

public record DeleteVideoCommand(int Id) : IRequest<Unit>;