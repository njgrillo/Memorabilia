namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class GradeFilterRule : IFilterRule<AutographViewModel>
{
    private int? _grade;

    public bool Applies(FilterItemEnum filterItemEnum, object value)
    {
        if (filterItemEnum != FilterItemEnum.AutographGrade)
            return false;

        _grade = (int?)value;

        return _grade.HasValue && _grade.Value > 0;
    }

    public Expression<Func<AutographViewModel, bool>> GetExpression()
    {
        Expression<Func<AutographViewModel, bool>> expression = autograph => autograph.Grade == _grade;

        return expression;
    }
}
