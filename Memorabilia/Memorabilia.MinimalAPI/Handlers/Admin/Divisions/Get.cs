namespace Memorabilia.MinimalAPI.Handlers.Admin.Divisions;

public class Get
    : RequestHandler<DivisionRequest>, IRequestHandler<DivisionRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(DivisionRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Division>(await Mediator.Send(new GetDivision(request.Id))));
}
