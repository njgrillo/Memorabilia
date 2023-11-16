namespace Memorabilia.Application.Services.Filters.Memorabilia.Rules;

public class ColorFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _colorIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographColor)
            return false;

        _colorIds = (int[])value;

        return _colorIds.HasAny();
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => item => item.Autographs.Any(autograph => _colorIds.Contains(autograph.ColorId));
}
