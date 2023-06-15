namespace Memorabilia.MinimalAPI.Handlers.Admin.PhotoTypes;

public class Get
    : RequestHandler<PhotoTypeRequest>, IRequestHandler<PhotoTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PhotoTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetPhotoType(request.Id))));
}
