namespace Memorabilia.MinimalAPI.Handlers.Admin.Colleges;

public class GetAll
    : RequestHandler<CollegesRequest>, IRequestHandler<CollegesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(CollegesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetColleges()));

        return Results.Ok(response);
    }
}
