namespace Memorabilia.MinimalAPI.Handlers.Admin.Sports;

public class Get
    : RequestHandler<SportRequest>, IRequestHandler<SportRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(SportRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Sport>(await Mediator.Send(new GetSport(request.Id))));
}
