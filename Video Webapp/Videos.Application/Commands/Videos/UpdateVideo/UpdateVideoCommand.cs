using MediatR;

namespace Videos.Application.Commands.Videos.UpdateVideo;

public record UpdateVideoCommand(int Id, string Title, string Description, string Category) : IRequest<Unit>;