using MediatR;
using Videos.Contracts.Responses;

namespace Videos.Application.Queries.Videos.GetVideos;

public record GetVideosQuery() : IRequest<GetVideosResponse>;