using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Videos.Contracts.Responses;
using Videos.Infrastructure;

namespace Videos.Application.Queries.Videos.GetVideos;

public class GetVideosQueryHandler : IRequestHandler<GetVideosQuery, GetVideosResponse>
{
    private readonly VideosDbContext _videosDbContext;
    
    public GetVideosQueryHandler(VideosDbContext videosDbContext)
    {
        _videosDbContext = videosDbContext;
    }
    
    public async Task<GetVideosResponse> Handle(GetVideosQuery request, CancellationToken cancellationToken)
    {
        var videos = await _videosDbContext.Videos.ToListAsync(cancellationToken);
        
        return videos.Adapt<GetVideosResponse>();
    }
}