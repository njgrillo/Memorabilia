namespace Memorabilia.MinimalAPI.Handlers.Admin.FigureTypes;

public class Get
    : RequestHandler<FigureTypeRequest>, IRequestHandler<FigureTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(FigureTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetFigureType(request.Id))));
}
