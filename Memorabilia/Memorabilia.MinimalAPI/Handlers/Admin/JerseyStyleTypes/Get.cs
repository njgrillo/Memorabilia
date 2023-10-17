namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyStyleTypes;

public class Get
    : RequestHandler<JerseyStyleTypeRequest>, IRequestHandler<JerseyStyleTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(JerseyStyleTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetJerseyStyleType(request.Id))));
}
