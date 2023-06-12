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

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Leagues.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Leagues.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Leagues.Item;

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Leagues.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport League Level is required.")]
    public int SportLeagueLevelId { get; set; }
}
