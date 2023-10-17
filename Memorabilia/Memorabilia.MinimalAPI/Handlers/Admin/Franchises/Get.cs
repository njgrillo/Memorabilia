namespace Memorabilia.MinimalAPI.Handlers.Admin.Franchises;

public class Get
    : RequestHandler<FranchiseRequest>, IRequestHandler<FranchiseRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FranchiseRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Franchise>(await Mediator.Send(new GetFranchise(request.Id))));
}
