namespace Memorabilia.MinimalAPI.Handlers.Admin.Divisions;

public class GetAll
    : RequestHandler<DivisionsRequest>, IRequestHandler<DivisionsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(DivisionsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Division[]>(await Mediator.Send(new GetDivisions()));

        return Results.Ok(response);
    }
}
