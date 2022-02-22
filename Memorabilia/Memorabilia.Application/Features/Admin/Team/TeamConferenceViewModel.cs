namespace Memorabilia.Application.Features.Admin.Team
{
    public class TeamConferenceViewModel
    {
        private readonly Domain.Entities.TeamConference _teamConference;

        public TeamConferenceViewModel() { }

        public TeamConferenceViewModel(Domain.Entities.TeamConference teamConference)
        {
            _teamConference = teamConference;
        }

        public int? BeginYear => _teamConference.BeginYear;

        public int ConferenceId => _teamConference.ConferenceId;

        public int? EndYear => _teamConference.EndYear;

        public int Id => _teamConference.Id;

        public int TeamId => _teamConference.TeamId;
    }
}
