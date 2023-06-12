namespace Memorabilia.Blazor.Pages.Team;

public partial class TeamConferenceEditor
{
    [Parameter]
    public List<TeamConferenceEditModel> Conferences { get; set; } 
        = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected TeamConferenceEditModel Model
        = new();

    private bool _canAdd 
        = true;

    private bool _canEditConference 
        = true;

    private bool _canUpdate;    

    private void Add()
    {
        Conferences.Add(Model);

        Model = new();
    }

    private void Edit(TeamConferenceEditModel conference)
    {
        Model.ConferenceId = conference.ConferenceId;
        Model.BeginYear = conference.BeginYear;
        Model.EndYear = conference.EndYear;

        _canAdd = false;
        _canEditConference = false;
        _canUpdate = true;
    }

    private void Update()
    {
        TeamConferenceEditModel conference 
            = Conferences.Single(conference => conference.ConferenceId == Model.ConferenceId);

        conference.ConferenceId  = Model.ConferenceId;
        conference.BeginYear = Model.BeginYear;
        conference.EndYear = Model.EndYear;

        Model = new();

        _canAdd = false;
        _canEditConference = false;
        _canUpdate = true;
    }
}
