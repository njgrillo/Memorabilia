namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class PersonFilterRule : IFilterRule<MemorabiliaItemViewModel>
{
    private int? _personId;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.MemorabiliaPerson)
            return false;

        _personId = (int?)value;

        return _personId.HasValue && _personId.Value > 0;
    }

    public Expression<Func<MemorabiliaItemViewModel, bool>> GetExpression()
    {
        Expression<Func<MemorabiliaItemViewModel, bool>> expression = item => item.People.Select(person => person.PersonId).Contains(_personId.Value);

        return expression;
    }
}
