namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonCollegeRetiredNumberEditor
{
    [Parameter]
    public List<SavePersonCollegeRetiredNumberViewModel> CollegeRetiredNumbers { get; set; } = new();

    [Parameter]
    public College[] Colleges { get; set; }

    private bool _canAdd = true;
    private bool _canEditCollege = true;
    private bool _canUpdate;
    private SavePersonCollegeRetiredNumberViewModel _viewModel = new();

    private void Add()
    {
        CollegeRetiredNumbers.Add(_viewModel);

        _viewModel = new SavePersonCollegeRetiredNumberViewModel();
    }

    private void Edit(SavePersonCollegeRetiredNumberViewModel CollegeRetiredNumber)
    {
        _viewModel.College = CollegeRetiredNumber.College;
        _viewModel.PlayerNumber = CollegeRetiredNumber.PlayerNumber;

        _canAdd = false;
        _canEditCollege = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var number = CollegeRetiredNumbers.Single(number => number.College.Id == _viewModel.College.Id);

        number.College = _viewModel.College;
        number.PlayerNumber = _viewModel.PlayerNumber;

        _viewModel = new SavePersonCollegeRetiredNumberViewModel();

        _canAdd = true;
        _canEditCollege = true;
        _canUpdate = false;
    }
}
