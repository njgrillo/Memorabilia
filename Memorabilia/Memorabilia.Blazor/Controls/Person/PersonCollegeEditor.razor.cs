#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonCollegeEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonCollegeViewModel> Colleges { get; set; } = new();

    private bool _canAdd = true;
    private bool _canEditCollege = true;
    private bool _canUpdate;
    private SavePersonCollegeViewModel _viewModel = new();

    private void Add()
    {
        Colleges.Add(_viewModel);

        _viewModel = new SavePersonCollegeViewModel();
    }

    private void Edit(SavePersonCollegeViewModel college)
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

        _viewModel = new SavePersonCollegeViewModel();

        _canAdd = false;
        _canEditCollege = false;
        _canUpdate = true;
    }
}
