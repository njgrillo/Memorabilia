namespace Memorabilia.MinimalAPI.Handlers.Admin.CerealTypes;

public class GetAll
    : RequestHandler<CerealTypesRequest>, IRequestHandler<CerealTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(CerealTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetCerealTypes()));

        return Results.Ok(response);
    }
}
