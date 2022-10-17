namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SportLeagueLevelFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _sportLeagueLevelId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaSportLeagueLevel)
            return false;

        _sportLeagueLevelId = (int)value;

        return _sportLeagueLevelId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.SportLeagueLevels.Select(sportLeagueLevel => sportLeagueLevel.Id).Contains(_sportLeagueLevelId);

        return expression;
    }
}
