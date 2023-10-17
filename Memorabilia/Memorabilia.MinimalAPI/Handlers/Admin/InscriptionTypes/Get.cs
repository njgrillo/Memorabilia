namespace Memorabilia.MinimalAPI.Handlers.Admin.InscriptionTypes;

public class Get
    : RequestHandler<InscriptionTypeRequest>, IRequestHandler<InscriptionTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(InscriptionTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetInscriptionType(request.Id))));
}
