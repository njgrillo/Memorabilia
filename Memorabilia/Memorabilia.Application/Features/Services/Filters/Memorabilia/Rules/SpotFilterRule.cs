namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class SpotFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int[] _spotIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographSpot)
            return false;

        _spotIds = (int[])value;

        return _spotIds.Any();
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => item.Autographs.Any(autograph => _spotIds.Contains(autograph.Spot.SpotId));
    }
}
