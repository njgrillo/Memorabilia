namespace Memorabilia.MinimalAPI.Handlers.Admin.FootballTypes;

public class GetAll
    : RequestHandler<FootballTypesRequest>, IRequestHandler<FootballTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FootballTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetFootballTypes()));

        return Results.Ok(response);
    }
}
