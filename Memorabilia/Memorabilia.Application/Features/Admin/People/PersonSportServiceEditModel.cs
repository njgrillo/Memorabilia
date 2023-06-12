namespace Memorabilia.Application.Features.Admin.People;

public class PersonSportServiceEditModel : EditModel
{
    public PersonSportServiceEditModel() { }

    public PersonSportServiceEditModel(int personId, PersonSportServiceModel model)
    {
        Colleges = model.Colleges.ToEditModelList();
        DebutDate = model.Service?.DebutDate;
        Drafts = model.Drafts.ToEditModelList();
        FreeAgentSigningDate = model.Service?.FreeAgentSigningDate;
        LastAppearanceDate = model.Service?.LastAppearanceDate;
        PersonId = personId;
        SportIds = model.Sports
                        .Select(sport => sport.SportId)
                        .ToList();    
    }

    public override string BackNavigationPath
        => $"{Constant.AdminDomainItem.People.Title}/{Constant.AdminDomainItem.Occupations.Item}/{Constant.EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/{Constant.AdminDomainItem.Teams.Item}/{Constant.EditModeType.Update.Name}/{PersonId}";

    public List<PersonCollegeEditModel> Colleges { get; set; } 
        = new();

    public DateTime? DebutDate { get; set; }

    public List<PersonDraftEditModel> Drafts { get; set; } 
        = new();

    public override Constant.EditModeType EditModeType 
        => Drafts.Any() ||
           DebutDate.HasValue || 
           FreeAgentSigningDate.HasValue || 
           LastAppearanceDate.HasValue 
            ? Constant.EditModeType.Update 
            : Constant.EditModeType.Add;

    public DateTime? FreeAgentSigningDate { get; set; }

    public DateTime? LastAppearanceDate { get; set; }

    public string ImageFileName 
        => Constant.ImageFileName.Athletes;

    public override string ItemTitle 
        => "Sport Service";

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Update ? Constant.EditModeType.Update.Name : Constant.EditModeType.Add.Name)} {ItemTitle}";

    public int PersonId { get; set; }

    public Constant.PersonStep PersonStep
        => Constant.PersonStep.SportService;

    public PersonSportServiceEditModel Service { get; set; }

    public List<int> SportIds { get; set; }
}
