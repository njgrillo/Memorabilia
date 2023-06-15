namespace Memorabilia.MinimalAPI.Handlers.Admin.CerealTypes;

public class Get
    : RequestHandler<CerealTypeRequest>, IRequestHandler<CerealTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(CerealTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetCerealType(request.Id))));
}
