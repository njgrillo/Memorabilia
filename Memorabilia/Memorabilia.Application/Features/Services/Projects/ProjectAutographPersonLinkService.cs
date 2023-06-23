namespace Memorabilia.Application.Features.Services.Projects;

public class ProjectAutographPersonLinkService
{
    private readonly IMediator _mediator;

    public ProjectAutographPersonLinkService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Entity.Autograph[]> GetAutographs(Constant.ProjectType projectType,
                                                        Dictionary<string, object> parameters)
    {
        var autographs = Array.Empty<Entity.Autograph>();

        object itemTypeId = null;
        object teamId = null;
        object year = null;

        _ = parameters.TryGetValue("ItemTypeId", out itemTypeId);
        _ = parameters.TryGetValue("PersonId", out object personId);

        switch (projectType.ToString())
        {
            case "BaseballType":
                _ = parameters.TryGetValue("BaseballTypeId", out object baseballTypeId);
                _ = parameters.TryGetValue("BaseballTypeTeamId", out teamId);
                _ = parameters.TryGetValue("BaseballTypeYear", out year);

                autographs = await _mediator.Send(new GetProjectPersonAutographBaseballTypeLinks((int)itemTypeId,
                                                                                                 (int)personId,
                                                                                                 (int)baseballTypeId,
                                                                                                 (int?)teamId,
                                                                                                 (int?)year));                                                         

                break;
            case "Card":
                _ = parameters.TryGetValue("CardBrandId", out object brandId);
                _ = parameters.TryGetValue("CardTeamId", out teamId);
                _ = parameters.TryGetValue("CardYear", out year);

                autographs = await _mediator.Send(new GetProjectPersonAutographCardLinks((int)itemTypeId,
                                                                                         (int)personId,
                                                                                         (int)brandId,
                                                                                         (int?)teamId,
                                                                                         (int?)year));

                break;
            case "HallofFame":
                _ = parameters.TryGetValue("HallOfFameSportLeagueLevelId", out object sportLeagueLevelId);
                _ = parameters.TryGetValue("HallOfFameItemTypeId", out itemTypeId);
                _ = parameters.TryGetValue("HallOfFameYear", out year);

                autographs = await _mediator.Send(new GetProjectPersonAutographHallOfFameLinks((int)itemTypeId,
                                                                                               (int)personId,
                                                                                               (int)sportLeagueLevelId,
                                                                                               (int?)year));

                break;
            case "ItemType":
                _ = parameters.TryGetValue("MultiSignedItem", out object multiSignedItem);

                autographs = await _mediator.Send(new GetProjectPersonAutographItemTypeLinks((int)itemTypeId,
                                                                                             (int)personId,
                                                                                             (bool?)multiSignedItem));

                break;
            case "Team":
                _ = parameters.TryGetValue("TeamId", out teamId);
                _ = parameters.TryGetValue("TeamYear", out year);

                autographs = await _mediator.Send(new GetProjectPersonAutographTeamLinks((int)itemTypeId,
                                                                                         (int)personId,
                                                                                         (int)teamId,
                                                                                         (int?)year));

                break;
            case "WorldSeries":
                _ = parameters.TryGetValue("WorldSeriesTeamId", out teamId);
                _ = parameters.TryGetValue("WorldSeriesItemTypeId", out itemTypeId);
                _ = parameters.TryGetValue("WorldSeriesYear", out year);

                autographs = await _mediator.Send(new GetProjectPersonAutographWorldSeriesLinks((int)itemTypeId,
                                                                                                (int)personId,
                                                                                                (int)teamId,
                                                                                                (int?)year));

                break;
            default:
                break;
        }

        return autographs;
    }
}
