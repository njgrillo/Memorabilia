namespace Memorabilia.MinimalAPI.Handlers.Admin.BatTypes;

public class Get
    : RequestHandler<BatTypeRequest>, IRequestHandler<BatTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BatTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetBatType(request.Id))));
}
