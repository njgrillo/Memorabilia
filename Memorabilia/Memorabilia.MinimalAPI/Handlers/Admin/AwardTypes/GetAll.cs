namespace Memorabilia.MinimalAPI.Handlers.Admin.AwardTypes;

public class GetAll
    : RequestHandler<AwardTypesRequest>, IRequestHandler<AwardTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(AwardTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetAwardTypes()));

        return Results.Ok(response);
    }
}
