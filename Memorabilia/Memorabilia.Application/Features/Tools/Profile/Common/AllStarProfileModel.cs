namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class AllStarProfileModel(Entity.AllStar allStar, Entity.PersonTeam team)
{
    public string TeamName 
        => team != null
            ? $"{team.Team.Location} {team.Team.Name}"
            : string.Empty;

    public int Year 
        => allStar.Year;

    public bool Filter(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
               (isNumeric && Year == year);
    }
}
