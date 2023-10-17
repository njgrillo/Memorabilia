namespace Memorabilia.MinimalAPI.Handlers.Admin.WritingInstruments;

public class Get
    : RequestHandler<WritingInstrumentRequest>, IRequestHandler<WritingInstrumentRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(WritingInstrumentRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetWritingInstrument(request.Id))));
}
