namespace Memorabilia.MinimalAPI.Handlers.Admin.FigureSpecialtyTypes;

public class GetAll
    : RequestHandler<FigureSpecialtyTypesRequest>, IRequestHandler<FigureSpecialtyTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FigureSpecialtyTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetFigureSpecialtyTypes()));

        return Results.Ok(response);
    }
}
