namespace Memorabilia.Application.Features.Admin.Pewters;

public class PewtersModel : Model
{
    public PewtersModel() { }

    public PewtersModel(IEnumerable<Entity.Pewter> pewters)
    {
        Pewters = pewters.Select(pewter => new PewterModel(pewter))
                         .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ItemTitle 
        => Constant.AdminDomainItem.Pewters.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Pewters.Title;

    public List<PewterModel> Pewters { get; set; } 
        = [];

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Pewters.Page;
}
