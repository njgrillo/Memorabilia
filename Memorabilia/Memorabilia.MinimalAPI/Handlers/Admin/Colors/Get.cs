namespace Memorabilia.MinimalAPI.Handlers.Admin.Colors;

public class Get
    : RequestHandler<ColorRequest>, IRequestHandler<ColorRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(ColorRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetColor(request.Id))));
}
