namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyStyleTypes;

public class GetAll
    : RequestHandler<JerseyStyleTypesRequest>, IRequestHandler<JerseyStyleTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(JerseyStyleTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetJerseyStyleTypes()));

        return Results.Ok(response);
    }
}
