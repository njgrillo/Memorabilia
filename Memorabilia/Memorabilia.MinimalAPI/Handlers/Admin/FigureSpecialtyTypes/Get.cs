namespace Memorabilia.MinimalAPI.Handlers.Admin.FigureSpecialtyTypes;

public class Get
    : RequestHandler<FigureSpecialtyTypeRequest>, IRequestHandler<FigureSpecialtyTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(FigureSpecialtyTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetFigureSpecialtyType(request.Id))));
}
