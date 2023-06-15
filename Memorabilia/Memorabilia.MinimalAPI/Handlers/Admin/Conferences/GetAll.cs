namespace Memorabilia.MinimalAPI.Handlers.Admin.Conferences;

public class GetAll
    : RequestHandler<ConferencesRequest>, IRequestHandler<ConferencesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ConferencesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Conference[]>(await QueryRouter.Send(new GetConferences()));

        return Results.Ok(response);
    }
}
