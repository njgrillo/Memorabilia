namespace Memorabilia.MinimalAPI.Handlers.Admin.MagazineTypes;

public class Get
    : RequestHandler<MagazineTypeRequest>, IRequestHandler<MagazineTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(MagazineTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetMagazineType(request.Id))));
}
