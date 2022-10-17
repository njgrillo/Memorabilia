namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class ConditionFilterRule : IFilterRule<AutographViewModel>
{
    private int _conditionId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographCondition)
            return false;

        _conditionId = (int)value;

        return _conditionId > 0;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.ConditionId == _conditionId;

        return expression;
    }
}
