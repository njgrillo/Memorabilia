using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonHallOfFamesViewModel : SaveViewModel
{
    public SavePersonHallOfFamesViewModel() { }

    public SavePersonHallOfFamesViewModel(int personId, PersonHallOfFameViewModel viewModel)
    {
        PersonId = personId;
        FranchiseHallOfFames = viewModel.FranchiseHallOfFames.Select(hof => new SavePersonFranchiseHallOfFameViewModel(hof)).ToList();
        HallOfFames = viewModel.HallOfFames.Select(hof => new SavePersonHallOfFameViewModel(hof)).ToList();
        InternationalHallOfFames = viewModel.InternationalHallOfFames.Select(hof => new SavePersonInternationalHallOfFameViewModel(hof)).ToList();
        SportIds = viewModel.Sports.Select(sport => sport.SportId).ToArray();
        FranchiseHallOfFameTypes = FranchiseHallOfFameType.GetAll(SportIds);
        SportLeagueLevels = Domain.Constants.SportLeagueLevel.GetAll(SportIds);
    }

    public override string BackNavigationPath => $"{AdminDomainItem.People.Title}/Accolade/{EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath => $"{AdminDomainItem.People.Title}/Image/{EditModeType.Update.Name}/{PersonId}";

    public override EditModeType EditModeType => HallOfFames.Any() ? EditModeType.Update : EditModeType.Add;

    public List<SavePersonFranchiseHallOfFameViewModel> FranchiseHallOfFames { get; set; } = new();

    public FranchiseHallOfFameType[] FranchiseHallOfFameTypes { get; set; } = FranchiseHallOfFameType.All;

    public List<SavePersonHallOfFameViewModel> HallOfFames { get; set; } = new();

    public string ImagePath => Domain.Constants.ImagePath.Athletes;

    public List<SavePersonInternationalHallOfFameViewModel> InternationalHallOfFames { get; set; } = new();

    public override string ItemTitle => "Hall of Fames";

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} Hall of Fames";

    public int PersonId { get; set; }

    public PersonStep PersonStep => PersonStep.HallOfFame;

    public int[] SportIds { get; set; } = Array.Empty<int>();

    public Domain.Constants.SportLeagueLevel[] SportLeagueLevels { get; set; } = Domain.Constants.SportLeagueLevel.All;
}
