namespace Memorabilia.MinimalAPI.Handlers.Admin.PriorityTypes;

public class Get
    : RequestHandler<PriorityTypeRequest>, IRequestHandler<PriorityTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PriorityTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetPriorityType(request.Id))));
}
