namespace Memorabilia.MinimalAPI.Handlers.Admin.Brands;

public class Get
    : RequestHandler<BrandRequest>, IRequestHandler<BrandRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BrandRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetBrand(request.Id))));
}
