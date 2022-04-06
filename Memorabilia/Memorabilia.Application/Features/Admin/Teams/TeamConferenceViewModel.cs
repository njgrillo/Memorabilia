using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class TeamConferenceViewModel
    {
        private readonly TeamConference _teamConference;

        public TeamConferenceViewModel() { }

        public TeamConferenceViewModel(TeamConference teamConference)
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
