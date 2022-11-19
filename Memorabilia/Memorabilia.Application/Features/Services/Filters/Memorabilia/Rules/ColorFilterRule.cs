namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ColorFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int[] _colorIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographColor)
            return false;

        _colorIds = (int[])value;

        return _colorIds.Any();
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => item.Autographs.Any(autograph => _colorIds.Contains(autograph.ColorId));
    }
}
