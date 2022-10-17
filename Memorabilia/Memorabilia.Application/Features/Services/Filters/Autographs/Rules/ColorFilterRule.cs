namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class ColorFilterRule : IFilterRule<AutographViewModel>
{
    private int _colorId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographColor)
            return false;

        _colorId = (int)value;

        return _colorId > 0;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.ColorId == _colorId;

        return expression;
    }
}
