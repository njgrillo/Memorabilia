namespace Memorabilia.Application.Features.Admin.SportLeagueLevels;

public class SportLeagueLevelsModel : Model
{
    public SportLeagueLevelsModel() { }

    public SportLeagueLevelsModel(IEnumerable<Entity.SportLeagueLevel> sportLeagueLevels)
    {
        SportLeagueLevels = sportLeagueLevels.Select(sportLeagueLevel => new SportLeagueLevelModel(sportLeagueLevel))
                                             .OrderBy(sportLeagueLevel => sportLeagueLevel.SportName)
                                             .ThenBy(sportLeagueLevel => sportLeagueLevel.Name)
                                             .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle 
        => Constant.AdminDomainItem.SportLeagueLevels.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.SportLeagueLevels.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.SportLeagueLevels.Page;

    public List<SportLeagueLevelModel> SportLeagueLevels { get; set; } 
        = new();
}
