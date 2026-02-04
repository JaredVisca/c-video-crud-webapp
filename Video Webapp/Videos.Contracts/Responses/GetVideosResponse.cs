using Videos.Contracts.Dtos;

namespace Videos.Contracts.Responses;

public record GetVideosResponse(List<VideoDto> VideoDtos);