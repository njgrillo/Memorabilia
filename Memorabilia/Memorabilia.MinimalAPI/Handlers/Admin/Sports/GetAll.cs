namespace Memorabilia.MinimalAPI.Handlers.Admin.Sports;

public class GetAll
    : RequestHandler<SportsRequest>, IRequestHandler<SportsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(SportsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Sport[]>(await Mediator.Send(new GetSports()));

        return Results.Ok(response);
    }
}
