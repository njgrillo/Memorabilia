using MudBlazor;

namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class CostFilterRule : IFilterRule<AutographViewModel>
{
    private Range<decimal?> _range;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographCost)
            return false;

        _range = (Range<decimal?>)value;

        return _range.Start.HasValue || _range.End.HasValue;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.Cost >= (_range.Start ?? 0) && autograph.Cost <= (_range.End ?? decimal.MaxValue);

        return expression;
    }
}
