namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public class LeaguePresidentsModel : Model
{
    public LeaguePresidentsModel() { }

    public LeaguePresidentsModel(IEnumerable<Entity.LeaguePresident> presidents)
    {
        Presidents = presidents.Select(president => new LeaguePresidentModel(president))
                               .OrderBy(president => president.SportLeagueLevelName)
                               .ThenByDescending(president => president.BeginYear)
                               .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";    

    public override string ItemTitle 
        => Constant.AdminDomainItem.LeaguePresidents.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.LeaguePresidents.Title;

    public List<LeaguePresidentModel> Presidents { get; set; } 
        = [];

    public override string RoutePrefix 
        => Constant.AdminDomainItem.LeaguePresidents.Page;
}
