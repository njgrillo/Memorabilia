namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyTypes;

public class Get
    : RequestHandler<JerseyTypeRequest>, IRequestHandler<JerseyTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(JerseyTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetJerseyType(request.Id))));
}
