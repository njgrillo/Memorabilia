namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyTypes;

public class GetAll
    : RequestHandler<JerseyTypesRequest>, IRequestHandler<JerseyTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(JerseyTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetJerseyTypes()));

        return Results.Ok(response);
    }
}
