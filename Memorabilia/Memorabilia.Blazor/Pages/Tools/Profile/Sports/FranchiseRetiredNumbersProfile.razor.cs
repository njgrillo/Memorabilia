namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class FranchiseRetiredNumbersProfile : SportProfile
{
    private Entity.RetiredNumber[] FranchiseRetiredNumbers
        = [];

    protected override void OnParametersSet()
    {
        FranchiseRetiredNumbers = Person.RetiredNumbers
                                        .OrderBy(number => number.Franchise.Name)
                                        .ToArray();
    }
}
