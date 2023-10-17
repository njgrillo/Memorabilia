namespace Memorabilia.MinimalAPI.Handlers.Admin.Pewters;

public class Get
    : RequestHandler<PewterRequest>, IRequestHandler<PewterRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PewterRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Pewter>(await Mediator.Send(new GetPewter(request.Id))));
}
