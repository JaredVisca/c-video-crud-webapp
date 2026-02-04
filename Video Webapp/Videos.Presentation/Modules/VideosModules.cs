using MediatR;
using Videos.Application.Commands.Videos.CreateVideo;
using Videos.Application.Commands.Videos.DeleteVideo;
using Videos.Application.Commands.Videos.UpdateVideo;
using Videos.Application.Queries.Videos.GetVideoById;
using Videos.Application.Queries.Videos.GetVideos;
using Videos.Contracts.Requests.Videos;

namespace Videos.Presentation.Modules;

public static class VideosModules
{
    public static void AddVideosEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/videos", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var videos = await mediator.Send(new GetVideosQuery(), cancellationToken);
            return Results.Ok(videos);
        }).WithTags("Videos");

        app.MapGet("/api/videos/{id}", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var video = await mediator.Send(new GetVideoByIdQuery(id), cancellationToken);
            return Results.Ok(video);
        }).WithTags("Videos");
        
        app.MapPost("/api/videos", async (IMediator mediator, CreateVideoRequest createVideoRequest, CancellationToken cancellationToken) =>
        {
            var command = new CreateVideoCommand(createVideoRequest.Title, createVideoRequest.Description, createVideoRequest.Category);
            var result = await mediator.Send(command, cancellationToken);
            return Results.Ok(result);
        }).WithTags("Videos");

        app.MapPut("/api/videos/{id}", async (IMediator mediator, int id, UpdateVideoRequest updateVideoRequest,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateVideoCommand(id, updateVideoRequest.Title, updateVideoRequest.Description, updateVideoRequest.Category);
            var result = await mediator.Send(command, cancellationToken);
            return Results.Ok(result);
        }).WithTags("Videos");

        app.MapDelete("/api/videos/{id}", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var command = new DeleteVideoCommand(id);
            var result = await mediator.Send(command, cancellationToken);
            return Results.Ok(result);
        }).WithTags("Videos");
    }
}