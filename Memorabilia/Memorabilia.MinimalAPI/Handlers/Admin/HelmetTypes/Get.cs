namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetTypes;

public class Get
    : RequestHandler<HelmetTypeRequest>, IRequestHandler<HelmetTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(HelmetTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetHelmetType(request.Id))));
}
