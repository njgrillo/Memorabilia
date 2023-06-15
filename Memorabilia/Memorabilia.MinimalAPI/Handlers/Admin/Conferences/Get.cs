namespace Memorabilia.MinimalAPI.Handlers.Admin.Conferences;

public class Get
    : RequestHandler<ConferenceRequest>, IRequestHandler<ConferenceRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ConferenceRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Conference>(await QueryRouter.Send(new GetConference(request.Id))));
}
