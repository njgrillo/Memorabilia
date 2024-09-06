namespace Memorabilia.Application.Validators.DisplayCase;

public class DisplayCaseDimensionValidator : AbstractValidator<DisplayCaseDimensionEditModel>
{
    public DisplayCaseDimensionValidator()
    {
        RuleFor(x => x.ColumnIndex)
            .GreaterThan(-1)
            .WithName("Column Index")
            .WithMessage("Column Index is required.");

        RuleFor(x => x.RowCount)
            .GreaterThan(0)
            .WithName("Row Count")
            .WithMessage("Row Count is required.");
    }
}
