namespace Memorabilia.MinimalAPI.Handlers.Admin.WritingInstruments;

public class Get
    : RequestHandler<WritingInstrumentRequest>, IRequestHandler<WritingInstrumentRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(WritingInstrumentRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetWritingInstrument(request.Id))));
}
