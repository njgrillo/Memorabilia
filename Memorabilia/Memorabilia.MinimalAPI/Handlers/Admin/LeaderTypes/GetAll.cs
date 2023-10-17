namespace Memorabilia.MinimalAPI.Handlers.Admin.LeaderTypes;

public class GetAll
    : RequestHandler<LeaderTypesRequest>, IRequestHandler<LeaderTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(LeaderTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetLeaderTypes()));

        return Results.Ok(response);
    }
}
