namespace Memorabilia.MinimalAPI.Handlers.Admin.InscriptionTypes;

public class GetAll
    : RequestHandler<InscriptionTypesRequest>, IRequestHandler<InscriptionTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(InscriptionTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetInscriptionTypes()));

        return Results.Ok(response);
    }
}
