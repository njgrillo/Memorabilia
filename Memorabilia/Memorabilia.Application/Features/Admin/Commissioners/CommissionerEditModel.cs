namespace Memorabilia.Application.Features.Admin.Commissioners;

public class CommissionerEditModel : EditModel
{
    public CommissionerEditModel() { }

    public CommissionerEditModel(CommissionerModel model)
    {
        BeginYear = model.BeginYear;
        EndYear = model.EndYear;
        Id = model.Id;
        Person = new PersonModel(model.Person);
        SportLeagueLevelId = model.SportLeagueLevelId;
    }

    public int? BeginYear { get; set; }

    public override string ContinueNavigationPath
        => RoutePrefix;

    public int? EndYear { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Commissioners.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Commissioners.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Commissioners.Item;    

    public PersonModel Person { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Commissioners.Page;

    public Entity.Sport Sport { get; set; }

    public int SportLeagueLevelId { get; set; }
}
