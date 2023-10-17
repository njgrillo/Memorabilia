namespace Memorabilia.MinimalAPI.Handlers.Admin.AccomplishmentTypes;

public class Get 
    : RequestHandler<AccomplishmentTypeRequest>, IRequestHandler<AccomplishmentTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(AccomplishmentTypeRequest request, 
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetAccomplishmentType(request.Id))));
}
