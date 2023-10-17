namespace Memorabilia.MinimalAPI.Handlers.Admin.ChampionTypes;

public class Get
    : RequestHandler<ChampionTypeRequest>, IRequestHandler<ChampionTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(ChampionTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetChampionType(request.Id))));
}
