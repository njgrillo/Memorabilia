namespace Memorabilia.MinimalAPI.Handlers.Admin.Commissioners;

public class GetAll
    : RequestHandler<CommissionersRequest>, IRequestHandler<CommissionersRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(CommissionersRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<CommissionerApiModel[]>(
            (await Mediator.Send(new GetCommissioners())).ToModelArray()));
}
