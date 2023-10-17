namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyTypes;

public class GetAll
    : RequestHandler<JerseyTypesRequest>, IRequestHandler<JerseyTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(JerseyTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetJerseyTypes()));

        return Results.Ok(response);
    }
}
