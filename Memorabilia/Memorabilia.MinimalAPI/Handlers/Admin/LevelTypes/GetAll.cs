namespace Memorabilia.MinimalAPI.Handlers.Admin.LevelTypes;

public class GetAll
    : RequestHandler<LevelTypesRequest>, IRequestHandler<LevelTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(LevelTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetLevelTypes()));

        return Results.Ok(response);
    }
}
