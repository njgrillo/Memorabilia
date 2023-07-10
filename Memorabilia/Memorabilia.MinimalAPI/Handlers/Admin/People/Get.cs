namespace Memorabilia.MinimalAPI.Handlers.Admin.People;

public class Get
    : RequestHandler<PersonRequest>, IRequestHandler<PersonRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PersonRequest request,
                                               CancellationToken cancellationToken)
    {
        Entity.Person person = await QueryRouter.Send(new GetPerson(request.Id));

        return person != null
            ? Results.Ok(new Response<PersonApiModel>(person.ToModel()))
            : Results.NotFound(new Response<PersonApiModel>(new PersonApiModel()));
    }
}
