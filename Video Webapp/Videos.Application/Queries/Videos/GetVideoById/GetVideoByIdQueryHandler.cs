using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Videos.Application.Queries.Videos.GetVideos;
using Videos.Contracts.Responses;
using Videos.Infrastructure;

namespace Videos.Application.Queries.Videos.GetVideoById;

public class GetVideoByIdQueryHandler : IRequestHandler<GetVideoByIdQuery, GetVideoByIdResponse>
{
    private readonly VideosDbContext _videosDbContext;
    
    public GetVideoByIdQueryHandler(VideosDbContext videosDbContext)
    {
        _videosDbContext = videosDbContext;
    }
    
    public async Task<GetVideoByIdResponse> Handle(GetVideoByIdQuery request, CancellationToken cancellationToken)
    {
        var video = await _videosDbContext.Videos.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (video is null)
        {
            throw new Exception();
        }
        return video.Adapt<GetVideoByIdResponse>();
    }
}