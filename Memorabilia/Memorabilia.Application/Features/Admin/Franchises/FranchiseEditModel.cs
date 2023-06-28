namespace Memorabilia.Application.Features.Admin.Franchises;

public class FranchiseEditModel : EditModel
{
    public FranchiseEditModel() { }

    public FranchiseEditModel(FranchiseModel model)
    {            
        Id = model.Id;
        Location = model.Location;
        Name = model.Name;
        FoundYear = model.FoundYear;
        SportLeagueLevelId = model.SportLeagueLevelId;
    }

    public override string ContinueNavigationPath
        => RoutePrefix;

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Franchises.Page;

    public int FoundYear { get; set; } 
        = 1900;

    public string ImageFileName 
        => Constant.AdminDomainItem.Franchises.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Franchises.Item;

    public string Location { get; set; }

    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Franchises.Page;

    public int SportLeagueLevelId { get; set; }
}
