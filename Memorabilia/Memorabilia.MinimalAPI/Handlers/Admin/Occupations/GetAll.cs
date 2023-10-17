namespace Memorabilia.MinimalAPI.Handlers.Admin.Occupations;

public class GetAll
    : RequestHandler<OccupationsRequest>, IRequestHandler<OccupationsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(OccupationsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetOccupations()));

        return Results.Ok(response);
    }
}
