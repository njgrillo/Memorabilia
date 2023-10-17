namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetTypes;

public class GetAll
    : RequestHandler<HelmetTypesRequest>, IRequestHandler<HelmetTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(HelmetTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetHelmetTypes()));

        return Results.Ok(response);
    }
}
