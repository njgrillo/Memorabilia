namespace Memorabilia.Application.Validators.PrivateSigning.Promoter.CustomItemGroups;

public class CustomItemGroupsValidator : AbstractValidator<SaveCustomItemGroups.Command>
{
    public CustomItemGroupsValidator()
    {
        RuleForEach(x => x.CustomItemGroups)
            .SetValidator(new CustomItemGroupValidator());
    }
}
