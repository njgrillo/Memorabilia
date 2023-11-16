namespace Memorabilia.Application.Features.Admin.Leagues;

public class LeaguesModel : Model
{
    public LeaguesModel() { }

    public LeaguesModel(IEnumerable<Entity.League> leagues)
    {
        Leagues = leagues.Select(league => new LeagueModel(league))
                         .OrderBy(league => league.SportLeagueLevelName)
                         .ThenBy(league => league.Name)
                         .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle 
        => Constant.AdminDomainItem.Leagues.Item;

    public List<LeagueModel> Leagues { get; set; } 
        = [];

    public override string PageTitle 
        => Constant.AdminDomainItem.Leagues.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Leagues.Page;
}
