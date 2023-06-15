namespace Memorabilia.MinimalAPI.Handlers.Admin.RecordTypes;

public class Get
    : RequestHandler<RecordTypeRequest>, IRequestHandler<RecordTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(RecordTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetRecordType(request.Id))));
}
