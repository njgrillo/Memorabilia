namespace Memorabilia.MinimalAPI.Handlers.Admin.MagazineTypes;

public class Get
    : RequestHandler<MagazineTypeRequest>, IRequestHandler<MagazineTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(MagazineTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetMagazineType(request.Id))));
}
