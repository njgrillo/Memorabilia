namespace Memorabilia.Application.Validators.Admin.Management.Accomplishments.Records;

public class FranchiseRecordValidator : AbstractValidator<SaveFranchiseRecords.Command>
{
    public FranchiseRecordValidator()
    {
        RuleFor(x => x.FranchiseId)
            .GreaterThan(0)
            .WithName("Franchise")
            .WithMessage("Franchise is required.");

        RuleForEach(x => x.CareerFranchiseRecords)
            .SetValidator(new CareerFranchiseRecordValidator());

        RuleForEach(x => x.SingleSeasonFranchiseRecords)
            .SetValidator(new SingleSeasonFranchiseRecordValidator());
    }
}
