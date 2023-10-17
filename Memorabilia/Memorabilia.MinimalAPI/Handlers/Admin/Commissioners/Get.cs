namespace Memorabilia.MinimalAPI.Handlers.Admin.Commissioners;

public class Get
    : RequestHandler<CommissionerRequest>, IRequestHandler<CommissionerRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(CommissionerRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<CommissionerApiModel>(
            (await Mediator.Send(new GetCommissioner(request.Id))).ToModel()));
}