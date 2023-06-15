namespace Memorabilia.MinimalAPI.Handlers.Admin.Sports;

public class GetAll
    : RequestHandler<SportsRequest>, IRequestHandler<SportsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(SportsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Sport[]>(await QueryRouter.Send(new GetSports()));

        return Results.Ok(response);
    }
}
