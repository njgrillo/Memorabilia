namespace Memorabilia.MinimalAPI.Handlers.Admin.Brands;

public class GetAll
    : RequestHandler<BrandsRequest>, IRequestHandler<BrandsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(BrandsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetBrands()));

        return Results.Ok(response);
    }
}
