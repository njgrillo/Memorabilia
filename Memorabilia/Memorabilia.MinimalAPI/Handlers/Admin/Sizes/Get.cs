namespace Memorabilia.MinimalAPI.Handlers.Admin.Sizes;

public class Get
    : RequestHandler<SizeRequest>, IRequestHandler<SizeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(SizeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetSize(request.Id))));
}
