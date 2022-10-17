namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class ImageFilterRule : IFilterRule<AutographViewModel>
{
    private bool _noImages;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographImage)
            return false;

        _noImages = (bool)value;

        return _noImages;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.Images.Count == 0;

        return expression;
    }
}
