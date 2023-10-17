namespace Memorabilia.MinimalAPI.Handlers.Admin.AwardTypes;

public class Get
    : RequestHandler<AwardTypeRequest>, IRequestHandler<AwardTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(AwardTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetAwardType(request.Id))));
}
