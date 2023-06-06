namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SportFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _sportIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.MemorabiliaSport)
            return false;

        _sportIds = (int[])value;

        return _sportIds.Any();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
    {
        return item => item.Sports.Select(sport => sport.SportId).Any(sportId => _sportIds.Contains(sportId));
    }
}
