namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class SpotFilterRule : IFilterRule<AutographViewModel>
{
    private int[] _spotIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographSpot)
            return false;

        _spotIds = (int[])value;

        return _spotIds.Any();
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => _spotIds.Contains(autograph.SpotId ?? 0);

        return expression;
    }
}
