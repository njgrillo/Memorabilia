namespace Memorabilia.MinimalAPI.Handlers.Admin.AccomplishmentTypes;

public class Get 
    : RequestHandler<AccomplishmentTypeRequest>, IRequestHandler<AccomplishmentTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(AccomplishmentTypeRequest request, 
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetAccomplishmentType(request.Id))));
}
