using Memorabilia.Application.Features.Admin.People.Management.Accomplishments.FranchiseRecords;

namespace Memorabilia.Application.Validators.Admin.Management.Accomplishments.Records;

public class SingleSeasonFranchiseRecordValidator : AbstractValidator<SingleSeasonFranchiseRecordEditModel>
{
    public SingleSeasonFranchiseRecordValidator()
    {
        RuleFor(x => x.Person.Id)
            .GreaterThan(0)
            .WithName("Person")
            .WithMessage("Person is required.");

        RuleFor(x => x.Record)
            .NotNull()
            .WithName("Record")
            .WithMessage("Record is required.");

        RuleFor(x => x.Record)
            .MaximumLength(100)
            .WithName("Record")
            .WithMessage("Record must be a maximum of 100 characters or less.");

        RuleFor(x => x.RecordTypeId)
            .GreaterThan(0)
            .WithName("Record Type")
            .WithMessage("Record Type is required.");

        RuleFor(x => x.Year)
            .GreaterThan(0)
            .WithName("Year")
            .WithMessage("Year is required.");

        RuleFor(x => x.Year)
            .Must(x => DateTime.UtcNow.Year <= x)
            .WithName("Year")
            .WithMessage("Year cannot be in the future.");
    }
}
