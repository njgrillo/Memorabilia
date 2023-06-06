namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SportLeagueLevelFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _sportLeagueLevelIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaSportLeagueLevel)
            return false;

        _sportLeagueLevelIds = (int[])value;

        return _sportLeagueLevelIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
    {
        return item => item.Teams.Any(team => _sportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id));
    }
}
