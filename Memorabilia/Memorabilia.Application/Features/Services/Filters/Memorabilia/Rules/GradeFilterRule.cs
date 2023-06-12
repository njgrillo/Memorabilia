namespace Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;

public class GradeFilterRule : IFilterRule<Entity.Memorabilia>
{
    private int? _grade;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographGrade)
            return false;

        _grade = (int?)value;

        return _grade.HasValue && _grade.Value > 0;
    }

    public Expression<Func<Entity.Memorabilia, bool>> GetExpression()
        => item => item.Autographs.Any(autograph => autograph.Grade == _grade);
}
