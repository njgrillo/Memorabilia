

namespace Memorabilia.Blazor.Controls.Team;

public partial class TeamConferenceEditor : ComponentBase
{
    [Parameter]
    public List<TeamConferenceEditModel> Conferences { get; set; } = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private bool _canAdd = true;
    private bool _canEditConference = true;
    private bool _canUpdate;
    private TeamConferenceEditModel _viewModel = new();

    private void Add()
    {
        Conferences.Add(_viewModel);

        _viewModel = new();
    }

    private void Edit(TeamConferenceEditModel conference)
    {
        _viewModel.ConferenceId = conference.ConferenceId;
        _viewModel.BeginYear = conference.BeginYear;
        _viewModel.EndYear = conference.EndYear;

        _canAdd = false;
        _canEditConference = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var conference = Conferences.Single(conference => conference.ConferenceId == _viewModel.ConferenceId);

        conference.ConferenceId  = _viewModel.ConferenceId;
        conference.BeginYear = _viewModel.BeginYear;
        conference.EndYear = _viewModel.EndYear;

        _viewModel = new();

        _canAdd = false;
        _canEditConference = false;
        _canUpdate = true;
    }
}
