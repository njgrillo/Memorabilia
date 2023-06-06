namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ImageFilterRule : IFilterRule<Entity.Memorabilia>
{
    private bool _noImages;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographImage)
            return false;

        _noImages = (bool)value;

        return _noImages;
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
    {
        return item => item.Autographs.Any(autograph => autograph.Images.Count == 0);
    }
}
