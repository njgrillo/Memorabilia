using Memorabilia.Domain.Entities;

namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class FranchiseHallOfFameProfile : SportProfile
{
    private FranchiseHallOfFameProfileViewModel[] FranchiseHallOfFames = Array.Empty<FranchiseHallOfFameProfileViewModel>();

    protected override void OnParametersSet()
    {
        FranchiseHallOfFames = Person.FranchiseHallOfFames
                                     .Filter(Sport)
                                     .Select(hof => new FranchiseHallOfFameProfileViewModel(hof))
                                     .ToArray();
    }
}
