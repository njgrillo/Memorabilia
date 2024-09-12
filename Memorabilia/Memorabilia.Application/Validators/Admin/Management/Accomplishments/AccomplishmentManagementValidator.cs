namespace Memorabilia.Application.Validators.Admin.Management.Accomplishments;

public class AccomplishmentManagementValidator : AbstractValidator<SaveAccomplishmentManagement.Command>
{
    public AccomplishmentManagementValidator()
    {
        RuleFor(x => x.AccomplishmentTypeId)
            .GreaterThan(0)
            .WithName("AccomplishmentType")
            .WithMessage("Accomplishment Type is required.");

        RuleFor(x => x.NumberOfWinners)
           .GreaterThan(0)
           .When(x => !x.IgnoreManagement)
           .WithName("NumberOfWinners")
           .WithMessage("Occurrences/Winners must be greater than 0.");
    }
}
