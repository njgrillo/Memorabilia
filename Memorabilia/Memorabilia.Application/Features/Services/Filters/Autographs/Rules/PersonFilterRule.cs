namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class PersonFilterRule : IFilterRule<AutographViewModel>
{
    private int? _personId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographPerson)
            return false;

        _personId = (int?)value;

        return _personId.HasValue && _personId.Value > 0;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.PersonId == _personId;

        return expression;
    }
}
