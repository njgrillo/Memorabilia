namespace Memorabilia.Application.Features.Admin.Pewters;

public class PewterEditModel : EditModel
{
    public PewterEditModel() { }

    public PewterEditModel(PewterModel model)
    {
        FileName = model.ImageFileName;
        Franchise = Constant.Franchise.Find(model.FranchiseId);
        Id = model.Id;        
        SizeId = model.SizeId;
        TeamId = model.TeamId;
    }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Pewters.Page;

    [Required]
    public string FileName { get; set; }

    public Constant.Franchise Franchise { get; set; }

    public string ImageFileName 
        => Constant.AdminDomainItem.Pewters.ImageFileName;    

    public override string ItemTitle 
        => Constant.AdminDomainItem.Pewters.Item;    

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Pewters.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; }

    public Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.NationalFootballLeague;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Team is required.")]
    public int TeamId { get; set; }
}
