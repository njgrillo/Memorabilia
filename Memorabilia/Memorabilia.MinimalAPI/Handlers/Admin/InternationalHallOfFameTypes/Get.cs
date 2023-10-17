namespace Memorabilia.MinimalAPI.Handlers.Admin.InternationalHallOfFameTypes;

public class Get
    : RequestHandler<InternationalHallOfFameTypeRequest>, IRequestHandler<InternationalHallOfFameTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(InternationalHallOfFameTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetInternationalHallOfFameType(request.Id))));
}
