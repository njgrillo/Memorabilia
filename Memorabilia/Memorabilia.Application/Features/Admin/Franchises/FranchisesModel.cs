namespace Memorabilia.Application.Features.Admin.Franchises;

public class FranchisesModel : Model
{
    public FranchisesModel() { }

    public FranchisesModel(IEnumerable<Entity.Franchise> franchises)
    {
        Franchises = franchises.Select(franchise => new FranchiseModel(franchise))
                               .OrderBy(franchise => franchise.SportLeagueLevelName)
                               .ThenBy(franchise => franchise.Name)
                               .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<FranchiseModel> Franchises { get; set; } 
        = new();

    public override string ItemTitle 
        => Constant.AdminDomainItem.Franchises.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Franchises.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Franchises.Page;
}
