namespace Memorabilia.Blazor.Services;

public class TeamFilterService
{
    public static bool Filter(Entity.Team team, string search)
        => search.IsNullOrEmpty() ||
           team.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Franchise.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase);
}
