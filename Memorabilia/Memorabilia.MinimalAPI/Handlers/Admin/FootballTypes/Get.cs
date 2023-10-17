namespace Memorabilia.MinimalAPI.Handlers.Admin.FootballTypes;

public class Get
    : RequestHandler<FootballTypeRequest>, IRequestHandler<FootballTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FootballTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetFootballType(request.Id))));
}
