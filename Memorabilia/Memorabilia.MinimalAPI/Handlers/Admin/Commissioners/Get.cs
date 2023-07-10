namespace Memorabilia.MinimalAPI.Handlers.Admin.Commissioners;

public class Get
    : RequestHandler<CommissionerRequest>, IRequestHandler<CommissionerRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(CommissionerRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<CommissionerApiModel>(
            (await QueryRouter.Send(new GetCommissioner(request.Id))).ToModel()));
}