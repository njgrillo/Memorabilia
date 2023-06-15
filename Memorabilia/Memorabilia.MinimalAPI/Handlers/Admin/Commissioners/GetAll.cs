namespace Memorabilia.MinimalAPI.Handlers.Admin.Commissioners;

public class GetAll
    : RequestHandler<CommissionersRequest>, IRequestHandler<CommissionersRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(CommissionersRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<CommissionerAPIModel[]>(
            (await QueryRouter.Send(new GetCommissioners())).ToModelArray()));
}
