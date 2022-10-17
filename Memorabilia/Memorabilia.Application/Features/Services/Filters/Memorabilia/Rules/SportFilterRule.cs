namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SportFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int _sportId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaSport)
            return false;

        _sportId = (int)value;

        return _sportId > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.Sports.Select(sport => sport.SportId).Contains(_sportId);

        return expression;
    }
}
