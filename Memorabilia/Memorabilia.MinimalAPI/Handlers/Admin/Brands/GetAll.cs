namespace Memorabilia.MinimalAPI.Handlers.Admin.Brands;

public class GetAll
    : RequestHandler<BrandsRequest>, IRequestHandler<BrandsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BrandsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetBrands()));

        return Results.Ok(response);
    }
}
