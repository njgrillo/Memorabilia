namespace Memorabilia.MinimalAPI.Handlers.Admin.ImageTypes;

public class Get
    : RequestHandler<ImageTypeRequest>, IRequestHandler<ImageTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ImageTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetImageType(request.Id))));
}
