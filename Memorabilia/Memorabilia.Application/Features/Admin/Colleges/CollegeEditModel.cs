namespace Memorabilia.Application.Features.Admin.Colleges;

public class CollegeEditModel : EditModel
{
    public CollegeEditModel() { }

    public CollegeEditModel(CollegeModel model)
    {
        Abbreviation = model.Abbreviation;
        Id = model.Id;
        Name = model.Name;
    }

    public string Abbreviation { get; set; }

    public override string ContinueNavigationPath
        => RoutePrefix;

    public override string ExitNavigationPath
        => Constant.AdminDomainItem.Colleges.Page;

    public string ImageFileName
        => Constant.AdminDomainItem.Colleges.ImageFileName;

    public override string ItemTitle
        => Constant.AdminDomainItem.Colleges.Item;

    public override string RoutePrefix
        => Constant.AdminDomainItem.Colleges.Page;
}
