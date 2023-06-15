namespace Memorabilia.MinimalAPI.Handlers.Admin.InternationalHallOfFameTypes;

public class GetAll
    : RequestHandler<InternationalHallOfFameTypesRequest>, IRequestHandler<InternationalHallOfFameTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(InternationalHallOfFameTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetInternationalHallOfFameTypes()));

        return Results.Ok(response);
    }
}
