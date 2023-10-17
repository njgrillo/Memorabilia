namespace Memorabilia.MinimalAPI.Handlers.Admin.BammerTypes;

public class Get
    : RequestHandler<BammerTypeRequest>, IRequestHandler<BammerTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BammerTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetBammerType(request.Id))));
}
