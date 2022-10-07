using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonOccupationsViewModel : SaveViewModel
{
    public SavePersonOccupationsViewModel() { }

    public SavePersonOccupationsViewModel(int personId, PersonOccupationViewModel viewModel)
    {
        Occupations = viewModel.Occupations.Select(occupation => new SavePersonOccupationViewModel(occupation)).ToList();
        PersonId = personId;
        Sports = viewModel.Sports.Select(sport => new SavePersonSportViewModel(sport)).ToList();
    }

    public override string BackNavigationPath => $"{AdminDomainItem.People.Title}/{EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath => $"{AdminDomainItem.People.Title}/SportService/{EditModeType.Update.Name}/{PersonId}";

    public override EditModeType EditModeType => Occupations.Any() || Sports.Any() ? EditModeType.Update : EditModeType.Add;

    public bool HasAthleteOccupation => Occupations.Any(occupation => Occupation.IsSportOccupation(occupation.OccupationId));

    public string ImagePath => AdminDomainItem.Occupations.ImagePath;

    public override string ItemTitle => AdminDomainItem.Occupations.Title; 

    public List<SavePersonOccupationViewModel> Occupations { get; set; } = new();

    public int PersonId { get; set; }        

    public PersonStep PersonStep => PersonStep.Occupation;

    public List<SavePersonSportViewModel> Sports { get; set; } = new();
}
