namespace Memorabilia.MinimalAPI.Handlers.Admin.MagazineTypes;

public class GetAll
    : RequestHandler<MagazineTypesRequest>, IRequestHandler<MagazineTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(MagazineTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetMagazineTypes()));

        return Results.Ok(response);
    }
}
