using MediatR;
using Microsoft.EntityFrameworkCore;
using Videos.Infrastructure;

namespace Videos.Application.Commands.Videos.DeleteVideo;

public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand, Unit>
{
    private readonly VideosDbContext _videosDbContext;

    public DeleteVideoCommandHandler(VideosDbContext videosDbContext)
    {
        _videosDbContext = videosDbContext;
    }

    public async Task<Unit> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
    {
        var videoToDelete = await _videosDbContext.Videos.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (videoToDelete is null)
        {
            throw new Exception();
        }

        _videosDbContext.Videos.Remove(videoToDelete);
        await _videosDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}