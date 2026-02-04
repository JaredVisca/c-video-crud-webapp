using MediatR;
using Videos.Domain.Entities;
using Videos.Infrastructure;

namespace Videos.Application.Commands.Videos.CreateVideo;

public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, int>
{
    private readonly VideosDbContext _videosDbContext;

    public CreateVideoCommandHandler(VideosDbContext videosDbContext)
    {
        _videosDbContext = videosDbContext;
    }

    public async Task<int> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
    {
        var video = new Video
        {
            Title = request.Title,
            Category = request.Category,
            Description = request.Description,
            CreateDate = DateTime.Now.ToUniversalTime()
        };

        await _videosDbContext.Videos.AddAsync(video, cancellationToken);
        await _videosDbContext.SaveChangesAsync(cancellationToken);

        return video.Id;
    }
}