namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class TeamProfileModel(Entity.PersonTeam team)
{
    public string BeginYear 
        => team.BeginYear?.ToString() ?? string.Empty;

    public string EndYear 
        => team.EndYear?.ToString() ?? string.Empty;

    public string Name 
        => $"{team.Team.Location} {team.Team.Name}";

    public bool Filter(string search)
    {
        return search.IsNullOrEmpty() ||
               BeginYear == search ||
               EndYear == search ||
               Name.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
