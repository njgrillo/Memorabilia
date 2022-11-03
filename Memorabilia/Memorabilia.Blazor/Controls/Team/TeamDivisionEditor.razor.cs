#nullable disable

namespace Memorabilia.Blazor.Controls.Team;

public partial class TeamDivisionEditor : ComponentBase
{
    [Parameter]
    public List<SaveTeamDivisionViewModel> Divisions { get; set; } = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private bool _canAdd = true;
    private bool _canEditDivision = true;
    private bool _canUpdate;
    private SaveTeamDivisionViewModel _viewModel = new();

    private void Add()
    {
        Divisions.Add(_viewModel);

        _viewModel = new ();
    }

    private void Edit(SaveTeamDivisionViewModel division)
    {
        _viewModel.DivisionId = division.DivisionId;
        _viewModel.BeginYear = division.BeginYear;
        _viewModel.EndYear = division.EndYear;

        _canAdd = false;
        _canEditDivision = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var division = Divisions.Single(division => division.DivisionId == _viewModel.DivisionId);

        division.DivisionId = _viewModel.DivisionId;
        division.BeginYear = _viewModel.BeginYear;
        division.EndYear = _viewModel.EndYear;

        _viewModel = new ();

        _canAdd = false;
        _canEditDivision = false;
        _canUpdate = true;
    }
}
