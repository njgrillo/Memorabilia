﻿namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetFinishes;

public class GetAll
    : RequestHandler<HelmetFinishesRequest>, IRequestHandler<HelmetFinishesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(HelmetFinishesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetHelmetFinishes()));

        return Results.Ok(response);
    }
}
