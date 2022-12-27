namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonRetiredNumberEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonRetiredNumberViewModel> RetiredNumbers { get; set; } = new();

    [Parameter]
    public int[] SportIds { get; set; }    

    private bool _canAdd = true;
    private bool _canEditFranchise = true;
    private bool _canUpdate;
    private SavePersonRetiredNumberViewModel _viewModel = new();

    private void Add()
    {
        RetiredNumbers.Add(_viewModel);

        _viewModel = new SavePersonRetiredNumberViewModel();
    }

    private void Edit(SavePersonRetiredNumberViewModel retiredNumber)
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

        _viewModel = new SavePersonRetiredNumberViewModel();

        _canAdd = true;
        _canEditFranchise = true;
        _canUpdate = false;
    }
}
