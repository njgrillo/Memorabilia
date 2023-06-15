namespace Memorabilia.MinimalAPI.Handlers.Admin.WritingInstruments;

public class GetAll
    : RequestHandler<WritingInstrumentsRequest>, IRequestHandler<WritingInstrumentsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(WritingInstrumentsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetWritingInstruments()));

        return Results.Ok(response);
    }
}
