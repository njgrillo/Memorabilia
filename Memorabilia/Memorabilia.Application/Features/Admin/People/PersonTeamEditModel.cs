﻿namespace Memorabilia.Application.Features.Admin.People;

public class PersonTeamEditModel 
    : EditModel, IWithName, IWithValue<int>
{
    public PersonTeamEditModel() { }

    public PersonTeamEditModel(int personId, TeamModel team)
    {
        BeginYear = team.BeginYear;
        EndYear = team.EndYear;
        FranchiseName = team.FranchiseName;
        PersonId = personId;
        SportId = team.SportId;
        SportLeagueLevelId = team.SportLeagueLevel.Id;
        TeamDisplayName = team.DisplayName;
        TeamId = team.Id;
        TeamLocation = team.Location;
        TeamName = team.Name;
    }

    public PersonTeamEditModel(PersonTeamModel team)
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
        TeamDisplayName = team.TeamDisplayName;
        TeamRoleType = Constant.TeamRoleType.Find(team.TeamRoleTypeId);
    }

    public int? BeginYear { get; set; }        

    public int? EndYear { get; set; }

    public string FranchiseName { get; set; }

    public override string Name 
        => TeamDisplayName;

    public int PersonId { get; set; }    

    public int SportId { get; }

    public Constant.SportLeagueLevel SportLeagueLevel
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId);

    public int SportLeagueLevelId { get; }

    public string SportLeagueLevelName
        => SportLeagueLevel?.Name;

    public string TeamDisplayName { get; set; }

    public int TeamId { get; set; }

    public string TeamLocation { get; set; }

    public string TeamName { get; set; }

    public Constant.TeamRoleType TeamRoleType { get; set; } 
        = Constant.TeamRoleType.Player;

    public string TeamRoleTypeName 
        => TeamRoleType?.Name;

    int IWithValue<int>.Value 
        => Id;

    public bool Search(string search)
    {
        bool isYear = search.TryParse(out int year);

        return search.IsNullOrEmpty() ||
               FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               TeamName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               TeamLocation.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               TeamRoleTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && BeginYear == year) ||
               (isYear && EndYear == year);
    }
}
