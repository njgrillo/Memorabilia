namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetTypes;

public class GetAll
    : RequestHandler<HelmetTypesRequest>, IRequestHandler<HelmetTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(HelmetTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetHelmetTypes()));

        return Results.Ok(response);
    }
}
