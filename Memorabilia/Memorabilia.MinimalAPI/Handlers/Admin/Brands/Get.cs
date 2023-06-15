namespace Memorabilia.MinimalAPI.Handlers.Admin.Brands;

public class Get
    : RequestHandler<BrandRequest>, IRequestHandler<BrandRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(BrandRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetBrand(request.Id))));
}
