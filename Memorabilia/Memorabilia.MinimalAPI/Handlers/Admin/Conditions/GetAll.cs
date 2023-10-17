namespace Memorabilia.MinimalAPI.Handlers.Admin.Conditions;

public class GetAll
    : RequestHandler<ConditionsRequest>, IRequestHandler<ConditionsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(ConditionsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetConditions()));

        return Results.Ok(response);
    }
}
