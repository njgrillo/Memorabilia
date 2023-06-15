namespace Memorabilia.MinimalAPI.Handlers.Admin.RecordTypes;

public class GetAll
    : RequestHandler<RecordTypesRequest>, IRequestHandler<RecordTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(RecordTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetRecordTypes()));

        return Results.Ok(response);
    }
}
