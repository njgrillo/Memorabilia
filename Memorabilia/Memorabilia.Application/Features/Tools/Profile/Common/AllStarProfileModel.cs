namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class AllStarProfileModel(Entity.AllStar allStar, Entity.PersonTeam team)
{
    public string TeamName 
        => team != null
            ? $"{team.Team.Location} {team.Team.Name}"
            : string.Empty;

    public int Year 
        => allStar.Year;
}
