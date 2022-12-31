using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonHallOfFamesViewModel : SaveViewModel
{
    public SavePersonHallOfFamesViewModel() { }

    public SavePersonHallOfFamesViewModel(int personId, PersonHallOfFameViewModel viewModel)
    {
        PersonId = personId;
        CollegeHallOfFames = viewModel.CollegeHallOfFames.Select(hof => new SavePersonCollegeHallOfFameViewModel(hof)).ToList();
        FranchiseHallOfFames = viewModel.FranchiseHallOfFames.Select(hof => new SavePersonFranchiseHallOfFameViewModel(hof)).ToList();
        HallOfFames = viewModel.HallOfFames.Select(hof => new SavePersonHallOfFameViewModel(hof)).ToList();
        InternationalHallOfFames = viewModel.InternationalHallOfFames.Select(hof => new SavePersonInternationalHallOfFameViewModel(hof)).ToList();
        Sports = viewModel.Sports.Select(sport => Sport.Find(sport.SportId)).ToArray();
        SportLeagueLevels = SportLeagueLevel.GetAll(viewModel.Sports.Select(sport => sport.SportId).ToArray());
    }

    public override string BackNavigationPath => $"{AdminDomainItem.People.Title}/Accolade/{EditModeType.Update.Name}/{PersonId}";

    public List<SavePersonCollegeHallOfFameViewModel> CollegeHallOfFames { get; set; } = new();

    public override string ContinueNavigationPath => $"{AdminDomainItem.People.Title}/Image/{EditModeType.Update.Name}/{PersonId}";

    public override EditModeType EditModeType => HallOfFames.Any() ? EditModeType.Update : EditModeType.Add;

    public List<SavePersonFranchiseHallOfFameViewModel> FranchiseHallOfFames { get; set; } = new();

    public List<SavePersonHallOfFameViewModel> HallOfFames { get; set; } = new();

    public string ImageFileName => Domain.Constants.ImageFileName.Athletes;

    public List<SavePersonInternationalHallOfFameViewModel> InternationalHallOfFames { get; set; } = new();

    public override string ItemTitle => "Hall of Fames";

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} Hall of Fames";

    public int PersonId { get; set; }

    public PersonStep PersonStep => PersonStep.HallOfFame;

    public Sport[] Sports { get; set; } = Array.Empty<Sport>();

    public SportLeagueLevel[] SportLeagueLevels { get; set; } = SportLeagueLevel.All;
}
