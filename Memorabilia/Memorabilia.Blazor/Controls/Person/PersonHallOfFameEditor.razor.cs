

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonHallOfFameEditor : ComponentBase
{
    [Parameter]
    public List<PersonHallOfFameEditModel> HallOfFames { get; set; } = new();

    [Parameter]
    public SportLeagueLevel[] SportLeagueLevels { get; set; } = SportLeagueLevel.All;

    private bool _canAddHallOfFame = true;
    private bool _canEditSportLeagueLevel = true;
    private bool _canUpdateHallOfFame;
    private PersonHallOfFameEditModel _viewModel = new();

    protected override void OnInitialized()
    {
        if (SportLeagueLevels.Count() == 1)
            _viewModel.SportLeagueLevelId = SportLeagueLevels.First().Id;
    }

    private void Add()
    {
        if (_viewModel.SportLeagueLevelId == 0)
            return;

        HallOfFames.Add(_viewModel);

        _viewModel = new PersonHallOfFameEditModel();

        if (SportLeagueLevels.Count() == 1)
            _viewModel.SportLeagueLevelId = SportLeagueLevels.First().Id;
    }

    private void Edit(PersonHallOfFameEditModel hallOfFame)
    {
        _viewModel.BallotNumber = hallOfFame.BallotNumber;
        _viewModel.InductionYear = hallOfFame.InductionYear;
        _viewModel.SportLeagueLevelId = hallOfFame.SportLeagueLevelId;
        _viewModel.VotePercentage = hallOfFame.VotePercentage;

        _canAddHallOfFame = false;
        _canEditSportLeagueLevel = false;
        _canUpdateHallOfFame = true;
    }

    private void Update()
    {
        var hallOfFame = HallOfFames.Single(hof => hof.SportLeagueLevelId == _viewModel.SportLeagueLevelId);

        hallOfFame.BallotNumber = _viewModel.BallotNumber;
        hallOfFame.InductionYear = _viewModel.InductionYear;
        hallOfFame.VotePercentage = _viewModel.VotePercentage;

        _viewModel = new PersonHallOfFameEditModel();

        _canAddHallOfFame = true;
        _canEditSportLeagueLevel = true;
        _canUpdateHallOfFame = false;

        if (SportLeagueLevels.Count() == 1)
            _viewModel.SportLeagueLevelId = SportLeagueLevels.First().Id;
    }
}
