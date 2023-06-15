﻿namespace Memorabilia.MinimalAPI.Handlers.Admin.FranchiseHallOfFameTypes;

public class Get
    : RequestHandler<FranchiseHallOfFameTypeRequest>, IRequestHandler<FranchiseHallOfFameTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(FranchiseHallOfFameTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetFranchiseHallOfFameType(request.Id))));
}
