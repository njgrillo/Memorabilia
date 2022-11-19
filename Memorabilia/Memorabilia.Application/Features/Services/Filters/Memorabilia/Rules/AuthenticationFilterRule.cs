namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class AuthenticationFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private bool _hasAuthentication;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographAuthentication)
            return false;

        _hasAuthentication = (bool)value;

        return _hasAuthentication;
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => item.Autographs.Any(autograph => autograph.Authentications.Count > 0);
    }
}
