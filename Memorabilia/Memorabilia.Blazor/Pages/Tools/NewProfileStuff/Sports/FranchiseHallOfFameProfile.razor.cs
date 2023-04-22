using Memorabilia.Domain.Entities;

namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class FranchiseHallOfFameProfile
{
    [Parameter]
    public Person Person { get; set; }

    [Parameter]
    public Domain.Constants.Sport Sport { get; set; }

    private FranchiseHallOfFameProfileViewModel[] FranchiseHallOfFames = Array.Empty<FranchiseHallOfFameProfileViewModel>();

    protected override void OnParametersSet()
    {
        FranchiseHallOfFames = Person.FranchiseHallOfFames
                                     .Filter(Sport)
                                     .Select(hof => new FranchiseHallOfFameProfileViewModel(hof))
                                     .ToArray();
    }
}
