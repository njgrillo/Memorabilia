namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetFinishes;

public class GetAll
    : RequestHandler<HelmetFinishesRequest>, IRequestHandler<HelmetFinishesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(HelmetFinishesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetHelmetFinishes()));

        return Results.Ok(response);
    }
}
