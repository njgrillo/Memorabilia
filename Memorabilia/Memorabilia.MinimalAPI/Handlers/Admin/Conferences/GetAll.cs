namespace Memorabilia.MinimalAPI.Handlers.Admin.Conferences;

public class GetAll
    : RequestHandler<ConferencesRequest>, IRequestHandler<ConferencesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(ConferencesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Conference[]>(await Mediator.Send(new GetConferences()));

        return Results.Ok(response);
    }
}
