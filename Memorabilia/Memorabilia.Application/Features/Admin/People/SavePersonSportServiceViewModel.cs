using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonSportServiceViewModel : SaveViewModel
{
    public SavePersonSportServiceViewModel() { }

    public SavePersonSportServiceViewModel(int personId, PersonSportServiceViewModel viewModel)
    {
        Colleges = viewModel.Colleges.Select(college => new SavePersonCollegeViewModel(college)).ToList();
        DebutDate = viewModel.Service?.DebutDate;
        Drafts = viewModel.Drafts.Select(draft => new SavePersonDraftViewModel(draft)).ToList();
        FreeAgentSigningDate = viewModel.Service?.FreeAgentSigningDate;
        LastAppearanceDate = viewModel.Service?.LastAppearanceDate;
        PersonId = personId;
        SportIds = viewModel.Sports.Select(sport => sport.SportId).ToList();    
    }

    public override string BackNavigationPath => $"{AdminDomainItem.People.Title}/{AdminDomainItem.Occupations.Item}/{EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath => $"{AdminDomainItem.People.Title}/{AdminDomainItem.Teams.Item}/{EditModeType.Update.Name}/{PersonId}";

    public List<SavePersonCollegeViewModel> Colleges { get; set; } = new();

    public DateTime? DebutDate { get; set; }

    public List<SavePersonDraftViewModel> Drafts { get; set; } = new();

    public override EditModeType EditModeType => Drafts.Any() ||
                                                 DebutDate.HasValue || 
                                                 FreeAgentSigningDate.HasValue || 
                                                 LastAppearanceDate.HasValue ? EditModeType.Update : EditModeType.Add;

    public DateTime? FreeAgentSigningDate { get; set; }

    public DateTime? LastAppearanceDate { get; set; }

    public string ImageFileName => Domain.Constants.ImageFileName.Athletes;

    public override string ItemTitle => "Sport Service";

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} {ItemTitle}";

    public int PersonId { get; set; }

    public PersonStep PersonStep => PersonStep.SportService;

    public SavePersonSportServiceViewModel Service { get; set; }

    public List<int> SportIds { get; set; }
}
