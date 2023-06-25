namespace Memorabilia.Application.Features.Admin.Conferences;

public class ConferenceEditModel : EditModel
{
    public ConferenceEditModel() { }

    public ConferenceEditModel(ConferenceModel model)
    {
        Abbreviation = model.Abbreviation;
        Id = model.Id;
        Name = model.Name;
        SportLeagueLevelId = model.SportLeagueLevelId;
    }

    public string Abbreviation { get; set; }

    public override string ExitNavigationPath 
        => Constant.AdminDomainItem.Conferences.Page;

    public string ImageFileName 
        => Constant.AdminDomainItem.Conferences.ImageFileName;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Conferences.Item;

    public override string Name { get; set; }    

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Conferences.Page;

    public int SportLeagueLevelId { get; set; }
}
