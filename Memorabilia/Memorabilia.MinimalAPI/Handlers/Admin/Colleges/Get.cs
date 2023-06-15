namespace Memorabilia.MinimalAPI.Handlers.Admin.Colleges;

public class Get
    : RequestHandler<CollegeRequest>, IRequestHandler<CollegeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(CollegeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetCollege(request.Id))));
}