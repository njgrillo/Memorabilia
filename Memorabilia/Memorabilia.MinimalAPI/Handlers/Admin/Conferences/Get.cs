namespace Memorabilia.MinimalAPI.Handlers.Admin.Conferences;

public class Get
    : RequestHandler<ConferenceRequest>, IRequestHandler<ConferenceRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(ConferenceRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Conference>(await Mediator.Send(new GetConference(request.Id))));
}
