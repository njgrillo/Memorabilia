namespace Memorabilia.MinimalAPI.Handlers.Admin.RecordTypes;

public class GetAll
    : RequestHandler<RecordTypesRequest>, IRequestHandler<RecordTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(RecordTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetRecordTypes()));

        return Results.Ok(response);
    }
}
