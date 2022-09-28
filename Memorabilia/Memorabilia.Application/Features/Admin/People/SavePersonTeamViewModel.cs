namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonTeamViewModel : SaveViewModel
    {
        public SavePersonTeamViewModel() { }

        public SavePersonTeamViewModel(int personId, TeamViewModel team)
        {
            FranchiseName = team.FranchiseName;
            PersonId = personId;
            SportId = team.SportId;
            SportLeagueLevelId = team.SportLeagueLevel.Id;
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
            SportId = team.SportId;
            SportLeagueLevelId = team.SportLeagueLevelId;
            TeamRoleTypeId = team.TeamRoleTypeId;
        }

        public int? BeginYear { get; set; }        

        public int? EndYear { get; set; }

        public string FranchiseName { get; }

        public int PersonId { get; set; }

        public Domain.Constants.SportLeagueLevel SportLeagueLevel => Domain.Constants.SportLeagueLevel.Find(SportLeagueLevelId);

        public int SportId { get; }

        public int SportLeagueLevelId { get; }

        public string TeamDisplayName { get; }

        public int TeamId { get; set; }

        public string TeamLocation { get; }

        public string TeamName { get; }

        public int TeamRoleTypeId { get; set; }

        public string TeamRoleTypeName => Domain.Constants.TeamRoleType.Find(TeamRoleTypeId)?.Name;

        public Domain.Constants.TeamRoleType[] TeamRoleTypes => Domain.Constants.TeamRoleType.Get(SportLeagueLevel);
    }
}
