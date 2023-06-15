namespace Memorabilia.MinimalAPI.Handlers.Admin.Pewters;

public class Get
    : RequestHandler<PewterRequest>, IRequestHandler<PewterRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PewterRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Pewter>(await QueryRouter.Send(new GetPewter(request.Id))));
}
