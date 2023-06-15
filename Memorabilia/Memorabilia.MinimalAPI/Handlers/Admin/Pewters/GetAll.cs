namespace Memorabilia.MinimalAPI.Handlers.Admin.Pewters;

public class GetAll
    : RequestHandler<PewtersRequest>, IRequestHandler<PewtersRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PewtersRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Pewter[]>(await QueryRouter.Send(new GetPewters()));

        return Results.Ok(response);
    }
}
