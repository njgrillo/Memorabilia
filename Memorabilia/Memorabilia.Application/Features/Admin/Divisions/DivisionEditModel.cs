namespace Memorabilia.Application.Features.Admin.Divisions;

public class DivisionEditModel : EditModel
{
    public DivisionEditModel() { }

    public DivisionEditModel(DivisionModel model)
    {
        Abbreviation = model.Abbreviation;
        ConferenceId = model.ConferenceId ?? 0;
        Id = model.Id;
        LeagueId = model.LeagueId ?? 0;
        Name = model.Name;
    }

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public int ConferenceId { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Divisions.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Divisions.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Divisions.Item;

    public int LeagueId { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Divisions.Page;
}
