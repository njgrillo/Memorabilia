namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonFranchiseHallOfFameEditor : ComponentBase
{
    [Parameter]
    public List<PersonFranchiseHallOfFameEditModel> FranchiseHallOfFames { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    private bool _canAdd = true;
    private bool _canEditFranchise = true;
    private bool _canUpdate;
    private PersonFranchiseHallOfFameEditModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.FranchiseHallOfFameType == null)
            return;

        FranchiseHallOfFames.Add(_viewModel);

        _viewModel = new PersonFranchiseHallOfFameEditModel();
    }

    private void Edit(PersonFranchiseHallOfFameEditModel hallOfFame)
    {
        _viewModel.FranchiseHallOfFameType = hallOfFame.FranchiseHallOfFameType;
        _viewModel.Year = hallOfFame.Year;

        _canAdd = false;
        _canEditFranchise = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var hallOfFame = FranchiseHallOfFames.Single(hof => hof.FranchiseHallOfFameType.Id == _viewModel.FranchiseHallOfFameType.Id);

        hallOfFame.FranchiseHallOfFameType = _viewModel.FranchiseHallOfFameType;
        hallOfFame.Year = _viewModel.Year;

        _viewModel = new PersonFranchiseHallOfFameEditModel();

        _canAdd = true;
        _canEditFranchise = true;
        _canUpdate = false;
    }
}
