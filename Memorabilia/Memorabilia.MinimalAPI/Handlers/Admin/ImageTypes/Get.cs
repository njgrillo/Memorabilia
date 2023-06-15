namespace Memorabilia.MinimalAPI.Handlers.Admin.ImageTypes;

public class Get
    : RequestHandler<ImageTypeRequest>, IRequestHandler<ImageTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ImageTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetImageType(request.Id))));
}
