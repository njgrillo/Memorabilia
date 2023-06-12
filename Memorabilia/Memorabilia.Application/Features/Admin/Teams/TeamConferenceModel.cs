namespace Memorabilia.Application.Features.Admin.Teams;

public class TeamConferenceModel
{
    private readonly Entity.TeamConference _teamConference;

    public TeamConferenceModel() { }

    public TeamConferenceModel(Entity.TeamConference teamConference)
    {
        _teamConference = teamConference;
    }

    public int? BeginYear 
        => _teamConference.BeginYear;

    public int ConferenceId 
        => _teamConference.ConferenceId;

    public int? EndYear 
        => _teamConference.EndYear;

    public int Id 
        => _teamConference.Id;

    public int TeamId 
        => _teamConference.TeamId;
}
