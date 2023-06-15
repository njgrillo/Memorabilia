namespace Memorabilia.MinimalAPI.Handlers.Admin.Orientations;

public class GetAll
    : RequestHandler<OrientationsRequest>, IRequestHandler<OrientationsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(OrientationsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetOrientations()));

        return Results.Ok(response);
    }
}
