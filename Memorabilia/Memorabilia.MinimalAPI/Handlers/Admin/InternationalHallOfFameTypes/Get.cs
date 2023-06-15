namespace Memorabilia.MinimalAPI.Handlers.Admin.InternationalHallOfFameTypes;

public class Get
    : RequestHandler<InternationalHallOfFameTypeRequest>, IRequestHandler<InternationalHallOfFameTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(InternationalHallOfFameTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetInternationalHallOfFameType(request.Id))));
}
