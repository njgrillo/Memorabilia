namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class ColorFilterRule : IFilterRule<AutographViewModel>
{
    private int[] _colorIds;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographColor)
            return false;

        _colorIds = (int[])value;

        return _colorIds.Any();
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => _colorIds.Contains(autograph.ColorId);

        return expression;
    }
}
