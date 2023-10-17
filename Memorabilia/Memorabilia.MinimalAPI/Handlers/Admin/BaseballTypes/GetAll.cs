namespace Memorabilia.MinimalAPI.Handlers.Admin.BaseballTypes;

public class GetAll
    : RequestHandler<BaseballTypesRequest>, IRequestHandler<BaseballTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BaseballTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetBaseballTypes()));

        return Results.Ok(response);
    }
}
