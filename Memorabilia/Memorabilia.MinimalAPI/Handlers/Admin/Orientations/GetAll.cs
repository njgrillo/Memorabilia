namespace Memorabilia.MinimalAPI.Handlers.Admin.Orientations;

public class GetAll
    : RequestHandler<OrientationsRequest>, IRequestHandler<OrientationsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(OrientationsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetOrientations()));

        return Results.Ok(response);
    }
}
