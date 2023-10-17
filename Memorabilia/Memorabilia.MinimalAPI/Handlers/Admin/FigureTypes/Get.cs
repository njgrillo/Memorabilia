﻿namespace Memorabilia.MinimalAPI.Handlers.Admin.FigureTypes;

public class Get
    : RequestHandler<FigureTypeRequest>, IRequestHandler<FigureTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FigureTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetFigureType(request.Id))));
}
