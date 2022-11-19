namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SportLeagueLevelFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int[] _sportLeagueLevelIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaSportLeagueLevel)
            return false;

        _sportLeagueLevelIds = (int[])value;

        return _sportLeagueLevelIds.Any();
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => item.Teams.Any(team => _sportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id));
    }
}
