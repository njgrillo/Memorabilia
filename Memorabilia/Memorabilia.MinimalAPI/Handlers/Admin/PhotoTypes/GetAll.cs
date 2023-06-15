namespace Memorabilia.MinimalAPI.Handlers.Admin.PhotoTypes;

public class GetAll
    : RequestHandler<PhotoTypesRequest>, IRequestHandler<PhotoTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PhotoTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetPhotoTypes()));

        return Results.Ok(response);
    }
}
