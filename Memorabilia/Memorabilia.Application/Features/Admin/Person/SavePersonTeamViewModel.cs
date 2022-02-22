using Memorabilia.Application.Features.Admin.Team;

namespace Memorabilia.Application.Features.Admin.Person
{
    public class SavePersonTeamViewModel : SaveViewModel
    {
        public SavePersonTeamViewModel() { }

        public SavePersonTeamViewModel(int personId, TeamViewModel team)
        {
            PersonId = personId;
            TeamDisplayName = team.DisplayName;
            TeamId = team.Id;
            TeamName = team.Name;
        }

        public SavePersonTeamViewModel(PersonTeamViewModel team)
        {
            Id = team.Id;
            PersonId = team.PersonId;
            TeamId = team.TeamId;
            TeamName = team.TeamName;
            BeginYear = team.BeginYear;
            EndYear = team.EndYear;
        }

        public int? BeginYear { get; set; }        

        public int? EndYear { get; set; }

        public int PersonId { get; set; }

        public string TeamDisplayName { get; }

        public int TeamId { get; set; }

        public string TeamName { get; }
    }
}
