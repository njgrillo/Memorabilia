namespace Memorabilia.MinimalAPI.Handlers.Admin.MagazineTypes;

public class GetAll
    : RequestHandler<MagazineTypesRequest>, IRequestHandler<MagazineTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(MagazineTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetMagazineTypes()));

        return Results.Ok(response);
    }
}
