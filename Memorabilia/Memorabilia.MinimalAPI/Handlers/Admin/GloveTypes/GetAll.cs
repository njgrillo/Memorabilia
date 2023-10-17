namespace Memorabilia.MinimalAPI.Handlers.Admin.GloveTypes;

public class GetAll
    : RequestHandler<GloveTypesRequest>, IRequestHandler<GloveTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(GloveTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetGloveTypes()));

        return Results.Ok(response);
    }
}
