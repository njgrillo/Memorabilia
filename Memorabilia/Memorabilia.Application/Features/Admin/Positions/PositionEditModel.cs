namespace Memorabilia.Application.Features.Admin.Positions;

public class PositionEditModel : EditModel
{
    public PositionEditModel() { }

    public PositionEditModel(PositionModel model)
    {
        Abbreviation = model.Abbreviation;
        Id = model.Id;
        Name = model.Name;
        SportId = model.SportId;
    }

    public string Abbreviation { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Positions.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Positions.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Positions.Item;

    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Positions.Page;

    public int SportId { get; set; }
}
