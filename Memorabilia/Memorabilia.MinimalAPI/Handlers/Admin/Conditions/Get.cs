namespace Memorabilia.MinimalAPI.Handlers.Admin.Conditions;

public class Get
    : RequestHandler<ConditionRequest>, IRequestHandler<ConditionRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(ConditionRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetCondition(request.Id))));
}
