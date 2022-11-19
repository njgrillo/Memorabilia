namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class GradeFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private int? _grade;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographGrade)
            return false;

        _grade = (int?)value;

        return _grade.HasValue && _grade.Value > 0;
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => item.Autographs.Any(autograph => autograph.Grade == _grade);
    }
}
