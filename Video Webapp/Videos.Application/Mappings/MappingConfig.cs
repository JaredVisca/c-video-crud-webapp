using Mapster;
using Videos.Contracts.Responses;
using Videos.Domain.Entities;

namespace Videos.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Video>, GetVideosResponse>.NewConfig().Map(dest => dest.VideoDtos, src => src);

        TypeAdapterConfig<Video, GetVideoByIdResponse>.NewConfig().Map(dest => dest.VideoDto, src => src);
    }
}