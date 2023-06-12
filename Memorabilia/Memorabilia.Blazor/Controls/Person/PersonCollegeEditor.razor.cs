namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonCollegeEditor : ComponentBase
{
    [Parameter]
    public List<PersonCollegeEditModel> Colleges { get; set; } = new();    

    private bool _canAdd = true;
    private bool _canEditCollege = true;
    private bool _canUpdate;
    private PersonCollegeEditModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.College == null)
            return;

        Colleges.Add(_viewModel);

        _viewModel = new PersonCollegeEditModel();
    }

    private void Edit(PersonCollegeEditModel college)
    {
        _viewModel.College = college.College;
        _viewModel.BeginYear = college.BeginYear;
        _viewModel.EndYear = college.EndYear;

        _canAdd = false;
        _canEditCollege = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var college = Colleges.Single(college => college.College.Id == _viewModel.College.Id);

        college.College = _viewModel.College;
        college.BeginYear = _viewModel.BeginYear;
        college.EndYear = _viewModel.EndYear;

        _viewModel = new PersonCollegeEditModel();

        _canAdd = false;
        _canEditCollege = false;
        _canUpdate = true;
    }
}
