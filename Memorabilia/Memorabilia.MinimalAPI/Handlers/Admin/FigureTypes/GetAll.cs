namespace Memorabilia.MinimalAPI.Handlers.Admin.FigureTypes;

public class GetAll
    : RequestHandler<FigureTypesRequest>, IRequestHandler<FigureTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FigureTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetFigureTypes()));

        return Results.Ok(response);
    }
}
