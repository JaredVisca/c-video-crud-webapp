using MediatR;
using Videos.Contracts.Responses;

namespace Videos.Application.Queries.Videos.GetVideoById;

public record GetVideoByIdQuery(int Id) :  IRequest<GetVideoByIdResponse>;