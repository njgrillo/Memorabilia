namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class FranchiseRetiredNumbersProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    private Domain.Entities.RetiredNumber[] FranchiseRetiredNumbers;

    protected override void OnParametersSet()
    {
        FranchiseRetiredNumbers = Person.RetiredNumbers
                                        .OrderBy(number => number.Franchise.Name)
                                        .ToArray();
    }
}
