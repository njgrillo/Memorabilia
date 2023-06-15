namespace Memorabilia.MinimalAPI.Handlers.Admin.Divisions;

public class Get
    : RequestHandler<DivisionRequest>, IRequestHandler<DivisionRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(DivisionRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Division>(await QueryRouter.Send(new GetDivision(request.Id))));
}
