namespace Memorabilia.MinimalAPI.Handlers.Admin.LevelTypes;

public class Get
    : RequestHandler<LevelTypeRequest>, IRequestHandler<LevelTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(LevelTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetLevelType(request.Id))));
}
