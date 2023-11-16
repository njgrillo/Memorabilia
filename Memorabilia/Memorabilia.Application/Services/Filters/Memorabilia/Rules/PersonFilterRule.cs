namespace Memorabilia.Application.Services.Filters.Memorabilia.Rules;

public class PersonFilterRule : IFilterRule<Entity.Memorabilia>
{
    private FilterItemEnum _filterItem;
    private int? _personId;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographPerson &&
            filterItem != FilterItemEnum.MemorabiliaPerson)
            return false;

        _filterItem = filterItem;
        _personId = (int?)value;

        return _personId.HasValue && _personId.Value > 0;
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => _filterItem == FilterItemEnum.AutographPerson
            ? item => item.Autographs.Any(autograph => autograph.PersonId == _personId)
            : item => item.People.Select(person => person.PersonId).Contains(_personId.Value);
}
