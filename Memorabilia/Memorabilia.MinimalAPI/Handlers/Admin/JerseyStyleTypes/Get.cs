namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyStyleTypes;

public class Get
    : RequestHandler<JerseyStyleTypeRequest>, IRequestHandler<JerseyStyleTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(JerseyStyleTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetJerseyStyleType(request.Id))));
}
