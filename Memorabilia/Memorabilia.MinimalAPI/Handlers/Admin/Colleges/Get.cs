namespace Memorabilia.MinimalAPI.Handlers.Admin.Colleges;

public class Get
    : RequestHandler<CollegeRequest>, IRequestHandler<CollegeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(CollegeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetCollege(request.Id))));
}