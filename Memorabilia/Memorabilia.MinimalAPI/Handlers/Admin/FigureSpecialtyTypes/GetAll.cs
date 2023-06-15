namespace Memorabilia.MinimalAPI.Handlers.Admin.FigureSpecialtyTypes;

public class GetAll
    : RequestHandler<FigureSpecialtyTypesRequest>, IRequestHandler<FigureSpecialtyTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(FigureSpecialtyTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetFigureSpecialtyTypes()));

        return Results.Ok(response);
    }
}
