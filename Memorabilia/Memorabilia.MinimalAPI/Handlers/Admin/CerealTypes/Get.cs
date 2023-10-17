namespace Memorabilia.MinimalAPI.Handlers.Admin.CerealTypes;

public class Get
    : RequestHandler<CerealTypeRequest>, IRequestHandler<CerealTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(CerealTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetCerealType(request.Id))));
}
