namespace GraphinAllDay.MinimalAPI.Handlers.Admin.AccomplishmentTypes;

public class GetAll(IMediator mediator)
    : Handler.RequestHandler<AccomplishmentTypesRequest>(mediator), IRequestHandler<AccomplishmentTypesRequest, IResult>
{
    public override async Task<IResult> Handle(AccomplishmentTypesRequest request, 
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity[]>(
            await Mediator.Send(new GetAccomplishmentTypes(), cancellationToken)));
}
