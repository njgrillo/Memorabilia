namespace Memorabilia.MinimalAPI.Handlers.Admin.People;

public class Get
    : RequestHandler<PersonRequest>, IRequestHandler<PersonRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PersonRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Person>(await QueryRouter.Send(new GetPerson(request.Id))));
}
