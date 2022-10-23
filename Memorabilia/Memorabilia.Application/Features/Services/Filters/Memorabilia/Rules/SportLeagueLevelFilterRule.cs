namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SportLeagueLevelFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _sportLeagueLevelIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaSportLeagueLevel)
            return false;

        _sportLeagueLevelIds = (int[])value;

        return _sportLeagueLevelIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.SportLeagueLevels.Select(sportLeagueLevel => sportLeagueLevel.Id).Any(sportLeagueLevelId => _sportLeagueLevelIds.Contains(sportLeagueLevelId));

        return expression;
    }
}
