namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyTypes;

public class Get
    : RequestHandler<JerseyTypeRequest>, IRequestHandler<JerseyTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(JerseyTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetJerseyType(request.Id))));
}
