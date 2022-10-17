namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class SpotFilterRule : IFilterRule<AutographViewModel>
{
    private int _spotId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographSpot)
            return false;

        _spotId = (int)value;

        return _spotId > 0;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.SpotId == _spotId;

        return expression;
    }
}
