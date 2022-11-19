namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class ImageFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private bool _noImages;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographImage)
            return false;

        _noImages = (bool)value;

        return _noImages;
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => item.Autographs.Any(autograph => autograph.Images.Count == 0);
    }
}
