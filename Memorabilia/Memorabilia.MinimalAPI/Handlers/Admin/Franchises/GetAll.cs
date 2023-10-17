namespace Memorabilia.MinimalAPI.Handlers.Admin.Franchises;

public class GetAll
    : RequestHandler<FranchisesRequest>, IRequestHandler<FranchisesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FranchisesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Franchise[]>(await Mediator.Send(new GetFranchises()));

        return Results.Ok(response);
    }
}
