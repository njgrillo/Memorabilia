namespace Memorabilia.Application.Services.Projects;

public class ProjectMemorabiliaTeamLinkService(IMediator mediator)
{
    public async Task<Entity.Memorabilia[]> GetMemorabilia(Constant.ProjectType projectType,
                                                           Dictionary<string, object> parameters)
    {
        _ = parameters.TryGetValue("ItemTypeId", out object itemTypeId);
        _ = parameters.TryGetValue("TeamId", out object teamId);


        if (projectType == Constant.ProjectType.HelmetType)
        {
            _ = parameters.TryGetValue("HelmetTypeId", out object helmetTypeId);
            _ = parameters.TryGetValue("HelmetSizeId", out object helmetSizeId);
            _ = parameters.TryGetValue("HelmetFinishId", out object helmetFinishId);

            return await mediator.Send(new GetProjectMemorabiliaTeamLinksForHelmet((int)itemTypeId,
                                                                                   (int?)teamId,
                                                                                   (int?)helmetTypeId,
                                                                                   (int?)helmetSizeId,
                                                                                   (int?)helmetFinishId));
        }

        _ = parameters.TryGetValue("TeamYear", out object teamYear);

        return await mediator.Send(new GetProjectMemorabiliaTeamLinks((int)itemTypeId,
                                                                      (int?)teamId,
                                                                      (int?)teamYear));
    }
}
