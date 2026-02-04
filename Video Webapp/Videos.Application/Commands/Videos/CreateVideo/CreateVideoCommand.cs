using MediatR;

namespace Videos.Application.Commands.Videos.CreateVideo;

public record CreateVideoCommand(string Title, string Description, string Category) : IRequest<int>;