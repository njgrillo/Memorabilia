namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class AuthenticationFilterRule : IFilterRule<AutographViewModel>
{
    private bool _hasAuthentication;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographAuthentication)
            return false;

        _hasAuthentication = (bool)value;

        return _hasAuthentication;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.Authentications.Count > 0;

        return expression;
    }
}
