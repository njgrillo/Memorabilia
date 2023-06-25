namespace Memorabilia.Application.Features.Admin.Leagues;

public class LeagueEditModel : EditModel
{
    public LeagueEditModel() { }

    public LeagueEditModel(LeagueModel model)
    {
        Abbreviation = model.Abbreviation;
        Id = model.Id;
        Name = model.Name;
        SportLeagueLevelId = model.SportLeagueLevelId;
    }

    public string Abbreviation { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Leagues.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Leagues.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Leagues.Item;

    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Leagues.Page;

    public int SportLeagueLevelId { get; set; }
}
