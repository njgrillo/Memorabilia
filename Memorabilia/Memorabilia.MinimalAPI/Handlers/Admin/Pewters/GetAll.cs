namespace Memorabilia.MinimalAPI.Handlers.Admin.Pewters;

public class GetAll
    : RequestHandler<PewtersRequest>, IRequestHandler<PewtersRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PewtersRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Pewter[]>(await Mediator.Send(new GetPewters()));

        return Results.Ok(response);
    }
}
