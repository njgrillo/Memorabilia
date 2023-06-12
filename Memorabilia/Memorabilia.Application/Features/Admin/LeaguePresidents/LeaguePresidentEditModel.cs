namespace Memorabilia.Application.Features.Admin.LeaguePresidents;

public class LeaguePresidentEditModel : EditModel
{
    public LeaguePresidentEditModel() { }

    public LeaguePresidentEditModel(LeaguePresidentModel model)
    {
        BeginYear = model.BeginYear;
        EndYear = model.EndYear;
        Id = model.Id;
        LeagueId = model.LeagueId;
        Person = new PersonModel(model.Person);
        SportLeagueLevelId = model.SportLeagueLevelId;
    }

    public int? BeginYear { get; set; }

    public int? EndYear { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.LeaguePresidents.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.LeaguePresidents.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.LeaguePresidents.Item;

    [Required]
    public int LeagueId { get; set; }

    [Required]
    public PersonModel Person { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.LeaguePresidents.Page;

    public Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId);

    [Required]
    public int SportLeagueLevelId { get; set; }
}
