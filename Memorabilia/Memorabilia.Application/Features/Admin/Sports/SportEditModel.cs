namespace Memorabilia.Application.Features.Admin.Sports;

public class SportEditModel : EditModel
{
    public SportEditModel() { }

    public SportEditModel(SportModel model)
    {
        AlternateName = model.AlternateName;
        Id = model.Id;
        Name = model.Name;
    }

    public string AlternateName { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Sports.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Sports.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Sports.Item;

    public override string Name { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Sports.Page;
}
