namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SportFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int[] _sportIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaSport)
            return false;

        _sportIds = (int[])value;

        return _sportIds.Any();
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.Sports.Select(sport => sport.SportId).Any(sportId => _sportIds.Contains(sportId));

        return expression;
    }
}
