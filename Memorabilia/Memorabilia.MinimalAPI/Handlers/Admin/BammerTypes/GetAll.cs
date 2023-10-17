namespace Memorabilia.MinimalAPI.Handlers.Admin.BammerTypes;

public class GetAll
    : RequestHandler<BammerTypesRequest>, IRequestHandler<BammerTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BammerTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetBammerTypes()));

        return Results.Ok(response);
    }
}
