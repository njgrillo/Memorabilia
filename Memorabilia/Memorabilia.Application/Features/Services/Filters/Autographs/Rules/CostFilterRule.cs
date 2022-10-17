namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class CostFilterRule : IFilterRule<AutographViewModel>
{
    private decimal? _cost;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographCost)
            return false;

        _cost = (decimal?)value;

        return _cost.HasValue && _cost.Value > 0;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.Cost == _cost;

        return expression;
    }
}
