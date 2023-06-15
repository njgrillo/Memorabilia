namespace Memorabilia.MinimalAPI.Handlers.Admin.Occupations;

public class GetAll
    : RequestHandler<OccupationsRequest>, IRequestHandler<OccupationsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(OccupationsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetOccupations()));

        return Results.Ok(response);
    }
}
