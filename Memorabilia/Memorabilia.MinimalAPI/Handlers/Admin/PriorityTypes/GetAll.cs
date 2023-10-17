namespace Memorabilia.MinimalAPI.Handlers.Admin.PriorityTypes;

public class GetAll
    : RequestHandler<PriorityTypesRequest>, IRequestHandler<PriorityTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PriorityTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetPriorityTypes()));

        return Results.Ok(response);
    }
}
