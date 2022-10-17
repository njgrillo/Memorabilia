namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class InscriptionFilterRule : IFilterRule<AutographViewModel>
{
    private bool _hasInscriptions;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographInscription)
            return false;

        _hasInscriptions = (bool)value;

        return _hasInscriptions;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.Inscriptions.Count > 0;

        return expression;
    }
}
