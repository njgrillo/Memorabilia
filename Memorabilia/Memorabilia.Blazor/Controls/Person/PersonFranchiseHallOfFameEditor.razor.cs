namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonFranchiseHallOfFameEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonFranchiseHallOfFameViewModel> FranchiseHallOfFames { get; set; } = new();

    private bool _canAdd = true;
    private bool _canEditFranchise = true;
    private bool _canUpdate;
    private SavePersonFranchiseHallOfFameViewModel _viewModel = new();

    private void Add()
    {
        FranchiseHallOfFames.Add(_viewModel);

        _viewModel = new SavePersonFranchiseHallOfFameViewModel();
    }

    private void Edit(SavePersonFranchiseHallOfFameViewModel hallOfFame)
    {
        _viewModel.FranchiseId = hallOfFame.FranchiseId;
        _viewModel.Year = hallOfFame.Year;

        _canAdd = false;
        _canEditFranchise = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var hallOfFame = FranchiseHallOfFames.Single(hof => hof.FranchiseId == _viewModel.FranchiseId);

        hallOfFame.FranchiseId = _viewModel.FranchiseId;
        hallOfFame.Year = _viewModel.Year;

        _viewModel = new SavePersonFranchiseHallOfFameViewModel();

        _canAdd = true;
        _canEditFranchise = true;
        _canUpdate = false;
    }
}
