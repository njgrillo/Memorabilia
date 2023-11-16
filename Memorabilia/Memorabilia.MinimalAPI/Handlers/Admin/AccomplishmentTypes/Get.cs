namespace Memorabilia.MinimalAPI.Handlers.Admin.AccomplishmentTypes;

public class Get(IMediator mediator)
    : RequestHandler<AccomplishmentTypeRequest>(mediator), IRequestHandler<AccomplishmentTypeRequest, IResult>
{
    public override async Task<IResult> Handle(AccomplishmentTypeRequest request, 
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetAccomplishmentType(request.Id), cancellationToken)));
}
