namespace Memorabilia.MinimalAPI.Handlers.Admin.GloveTypes;

public class Get
    : RequestHandler<GloveTypeRequest>, IRequestHandler<GloveTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(GloveTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetGloveType(request.Id))));
}
