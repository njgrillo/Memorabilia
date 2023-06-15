namespace Memorabilia.MinimalAPI.Handlers.Admin.People;

public class GetAll
    : RequestHandler<PersonsRequest>, IRequestHandler<PersonsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PersonsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Person[]>(await QueryRouter.Send(new GetPeople()));

        return Results.Ok(response);
    }
}
