namespace Memorabilia.MinimalAPI.Handlers.Admin.PhotoTypes;

public class Get
    : RequestHandler<PhotoTypeRequest>, IRequestHandler<PhotoTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PhotoTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetPhotoType(request.Id))));
}
