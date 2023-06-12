namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonCollegeHallOfFameEditor
{
    [Parameter]
    public List<PersonCollegeHallOfFameEditModel> CollegeHallOfFames { get; set; } = new();

    [Parameter]
    public int[] SportIds { get; set; }

    private bool _canAdd = true;
    private bool _canEditCollege = true;
    private bool _canUpdate;
    private PersonCollegeHallOfFameEditModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.College == null)
            return;

        CollegeHallOfFames.Add(_viewModel);

        _viewModel = new PersonCollegeHallOfFameEditModel();
    }

    private void Edit(PersonCollegeHallOfFameEditModel hallOfFame)
    {
        _viewModel.College = hallOfFame.College;
        _viewModel.Sport = hallOfFame.Sport;
        _viewModel.Year = hallOfFame.Year;

        _canAdd = false;
        _canEditCollege = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var hallOfFame = CollegeHallOfFames.Single(hof => hof.Sport.Id == _viewModel.Sport.Id 
                                                          && hof.Sport.Id == _viewModel.Sport.Id);

        hallOfFame.College = _viewModel.College;
        hallOfFame.Sport = _viewModel.Sport;
        hallOfFame.Year = _viewModel.Year;

        _viewModel = new PersonCollegeHallOfFameEditModel();

        _canAdd = true;
        _canEditCollege = true;
        _canUpdate = false;
    }
}
