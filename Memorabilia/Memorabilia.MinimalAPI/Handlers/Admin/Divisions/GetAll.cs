namespace Memorabilia.MinimalAPI.Handlers.Admin.Divisions;

public class GetAll
    : RequestHandler<DivisionsRequest>, IRequestHandler<DivisionsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(DivisionsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Division[]>(await QueryRouter.Send(new GetDivisions()));

        return Results.Ok(response);
    }
}
