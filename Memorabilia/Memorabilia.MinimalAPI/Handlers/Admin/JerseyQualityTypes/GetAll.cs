namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyQualityTypes;

public class GetAll
    : RequestHandler<JerseyQualityTypesRequest>, IRequestHandler<JerseyQualityTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(JerseyQualityTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetJerseyQualityTypes()));

        return Results.Ok(response);
    }
}
