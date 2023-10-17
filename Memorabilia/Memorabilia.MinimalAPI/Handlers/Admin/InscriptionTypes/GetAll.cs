namespace Memorabilia.MinimalAPI.Handlers.Admin.InscriptionTypes;

public class GetAll
    : RequestHandler<InscriptionTypesRequest>, IRequestHandler<InscriptionTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(InscriptionTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetInscriptionTypes()));

        return Results.Ok(response);
    }
}
