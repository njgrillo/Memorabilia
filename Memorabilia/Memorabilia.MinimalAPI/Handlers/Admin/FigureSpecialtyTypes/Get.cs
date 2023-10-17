﻿namespace Memorabilia.MinimalAPI.Handlers.Admin.FigureSpecialtyTypes;

public class Get
    : RequestHandler<FigureSpecialtyTypeRequest>, IRequestHandler<FigureSpecialtyTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(FigureSpecialtyTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetFigureSpecialtyType(request.Id))));
}
