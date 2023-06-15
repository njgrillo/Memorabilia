namespace Memorabilia.MinimalAPI.Handlers.Admin.InscriptionTypes;

public class Get
    : RequestHandler<InscriptionTypeRequest>, IRequestHandler<InscriptionTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(InscriptionTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetInscriptionType(request.Id))));
}
