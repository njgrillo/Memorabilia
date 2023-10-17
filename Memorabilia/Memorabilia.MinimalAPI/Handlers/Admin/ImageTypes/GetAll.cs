namespace Memorabilia.MinimalAPI.Handlers.Admin.ImageTypes;

public class GetAll
    : RequestHandler<ImageTypesRequest>, IRequestHandler<ImageTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ImageTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetImageTypes()));

        return Results.Ok(response);
    }
}
