namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ColorFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int[] _colorIds;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographColor)
            return false;

        _colorIds = (int[])value;

        return _colorIds.Length != 0;
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => item => item.Autographs.Any(autograph => _colorIds.Contains(autograph.ColorId));
}
