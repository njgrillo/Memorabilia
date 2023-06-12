namespace Memorabilia.Application.Features.Admin.Commissioners;

public class CommissionersModel : Model
{
    public CommissionersModel() { }

    public CommissionersModel(IEnumerable<Entity.Commissioner> commissioners)
    {
        Commissioners = commissioners.Select(commissioner => new CommissionerModel(commissioner))
                                     .OrderBy(commissioner => commissioner.SportLeagueLevelName)
                                     .ThenByDescending(commissioner => commissioner.BeginYear)
                                     .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<CommissionerModel> Commissioners { get; set; } 
        = new();

    public override string ItemTitle 
        => Constant.AdminDomainItem.Commissioners.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Commissioners.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Commissioners.Page;
}
