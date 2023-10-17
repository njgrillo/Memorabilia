namespace GraphinAllDay.MinimalAPI.Handlers.Admin.AccomplishmentTypes;

public class GetAll 
    : Handler.RequestHandler<AccomplishmentTypesRequest>, IRequestHandler<AccomplishmentTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(AccomplishmentTypesRequest request, 
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity[]>(
            await Mediator.Send(new GetAccomplishmentTypes())));
}
