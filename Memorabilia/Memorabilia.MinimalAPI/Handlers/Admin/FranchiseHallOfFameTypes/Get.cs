namespace Memorabilia.MinimalAPI.Handlers.Admin.FranchiseHallOfFameTypes;

public class Get
    : RequestHandler<FranchiseHallOfFameTypeRequest>, IRequestHandler<FranchiseHallOfFameTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FranchiseHallOfFameTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetFranchiseHallOfFameType(request.Id))));
}
