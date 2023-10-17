namespace Memorabilia.MinimalAPI.Handlers.Admin.FranchiseHallOfFameTypes;

public class GetAll
    : RequestHandler<FranchiseHallOfFameTypesRequest>, IRequestHandler<FranchiseHallOfFameTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FranchiseHallOfFameTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetFranchiseHallOfFameTypes()));

        return Results.Ok(response);
    }
}
