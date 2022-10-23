namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class ConditionFilterRule : IFilterRule<AutographViewModel>
{
    private int[] _conditionIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographCondition)
            return false;

        _conditionIds = (int[])value;

        return _conditionIds.Any();
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => _conditionIds.Contains(autograph.ConditionId);

        return expression;
    }
}
