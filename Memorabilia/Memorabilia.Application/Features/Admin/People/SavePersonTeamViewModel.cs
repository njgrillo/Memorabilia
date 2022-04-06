using Memorabilia.Application.Features.Admin.Teams;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonTeamViewModel : SaveViewModel
    {
        public SavePersonTeamViewModel() { }

        public SavePersonTeamViewModel(int personId, TeamViewModel team)
        {
            FranchiseName = team.FranchiseName;
            PersonId = personId;
            TeamDisplayName = team.DisplayName;
            TeamId = team.Id;
            TeamLocation = team.Location;
            TeamName = team.Name;
        }

        public SavePersonTeamViewModel(PersonTeamViewModel team)
        {
            FranchiseName = team.FranchiseName;
            Id = team.Id;
            PersonId = team.PersonId;
            TeamId = team.TeamId;
            TeamLocation = team.TeamLocation;
            TeamName = team.TeamName;
            BeginYear = team.BeginYear;
            EndYear = team.EndYear;
        }

        public int? BeginYear { get; set; }        

        public int? EndYear { get; set; }

        public string FranchiseName { get; }

        public int PersonId { get; set; }

        public string TeamDisplayName { get; }

        public int TeamId { get; set; }

        public string TeamLocation { get; }

        public string TeamName { get; }
    }
}
