namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class EstimatedValueFilterRule : IFilterRule<AutographViewModel>
{
    private decimal? _estimatedValue;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographEstimatedValue)
            return false;

        _estimatedValue = (decimal?)value;

        return _estimatedValue.HasValue && _estimatedValue.Value > 0;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.EstimatedValue == _estimatedValue;

        return expression;
    }
}
