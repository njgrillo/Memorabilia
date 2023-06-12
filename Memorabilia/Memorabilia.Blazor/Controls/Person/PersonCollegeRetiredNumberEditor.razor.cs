namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonCollegeRetiredNumberEditor
{
    [Parameter]
    public List<PersonCollegeRetiredNumberEditModel> CollegeRetiredNumbers { get; set; } = new();

    [Parameter]
    public College[] Colleges { get; set; }

    private bool _canAdd = true;
    private bool _canEditCollege = true;
    private bool _canUpdate;
    private PersonCollegeRetiredNumberEditModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.College == null || !_viewModel.PlayerNumber.HasValue)
            return;

        CollegeRetiredNumbers.Add(_viewModel);

        _viewModel = new PersonCollegeRetiredNumberEditModel();
    }

    private void Edit(PersonCollegeRetiredNumberEditModel CollegeRetiredNumber)
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

        _viewModel = new PersonCollegeRetiredNumberEditModel();

        _canAdd = true;
        _canEditCollege = true;
        _canUpdate = false;
    }
}
