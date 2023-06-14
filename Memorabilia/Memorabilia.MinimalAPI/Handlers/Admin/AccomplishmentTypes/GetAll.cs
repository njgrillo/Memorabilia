namespace GraphinAllDay.MinimalAPI.Handlers.Admin.AccomplishmentTypes;

public class GetAll 
    : Handler.RequestHandler<AccomplishmentTypesRequest>, IRequestHandler<AccomplishmentTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(AccomplishmentTypesRequest request, 
                                               CancellationToken cancellationToken)
    {
        var response 
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetAccomplishmentTypes()));

        return Results.Ok(response);
    }
}
