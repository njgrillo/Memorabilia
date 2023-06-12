namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonRetiredNumberEditor : ComponentBase
{
    [Parameter]
    public List<PersonRetiredNumberEditModel> RetiredNumbers { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }    

    private bool _canAdd = true;
    private bool _canEditFranchise = true;
    private bool _canUpdate;
    private PersonRetiredNumberEditModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.Franchise == null || !_viewModel.PlayerNumber.HasValue)
            return;

        RetiredNumbers.Add(_viewModel);

        _viewModel = new PersonRetiredNumberEditModel();
    }

    private void Edit(PersonRetiredNumberEditModel retiredNumber)
    {
        _viewModel.Franchise = retiredNumber.Franchise;
        _viewModel.PlayerNumber = retiredNumber.PlayerNumber;

        _canAdd = false;
        _canEditFranchise = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var number = RetiredNumbers.Single(number => number.Franchise.Id == _viewModel.Franchise.Id);

        number.Franchise = _viewModel.Franchise;
        number.PlayerNumber = _viewModel.PlayerNumber;

        _viewModel = new PersonRetiredNumberEditModel();

        _canAdd = true;
        _canEditFranchise = true;
        _canUpdate = false;
    }
}
