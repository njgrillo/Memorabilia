namespace Memorabilia.MinimalAPI.Handlers.Admin.Colors;

public class GetAll
    : RequestHandler<ColorsRequest>, IRequestHandler<ColorsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(ColorsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetColors()));

        return Results.Ok(response);
    }
}
