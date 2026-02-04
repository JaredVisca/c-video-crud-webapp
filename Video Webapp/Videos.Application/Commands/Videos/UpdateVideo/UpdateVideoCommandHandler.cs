using MediatR;
using Microsoft.EntityFrameworkCore;
using Videos.Infrastructure;

namespace Videos.Application.Commands.Videos.UpdateVideo;

public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand, Unit>
{
    private readonly VideosDbContext _videosDbContext;

    public UpdateVideoCommandHandler(VideosDbContext videosDbContext)
    {
        _videosDbContext = videosDbContext;
    }
    
    public async Task<Unit> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
    {
        var videoToUpdate =
            await _videosDbContext.Videos.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (videoToUpdate is null)
        {
            throw new Exception();
        }

        videoToUpdate.Description = request.Description;
        videoToUpdate.Title = request.Title;
        videoToUpdate.Category = request.Category;

        _videosDbContext.Videos.Update(videoToUpdate);
        await _videosDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}