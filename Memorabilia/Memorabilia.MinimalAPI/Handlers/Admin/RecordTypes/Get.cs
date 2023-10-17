namespace Memorabilia.MinimalAPI.Handlers.Admin.RecordTypes;

public class Get
    : RequestHandler<RecordTypeRequest>, IRequestHandler<RecordTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(RecordTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetRecordType(request.Id))));
}
