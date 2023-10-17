namespace Memorabilia.MinimalAPI.Handlers.Admin.BaseballTypes;

public class Get
    : RequestHandler<BaseballTypeRequest>, IRequestHandler<BaseballTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BaseballTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetBaseballType(request.Id))));
}
