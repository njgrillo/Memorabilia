namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class FranchiseHallOfFameProfile : SportProfile
{
    private FranchiseHallOfFameProfileModel[] FranchiseHallOfFames 
        = Array.Empty<FranchiseHallOfFameProfileModel>();

    protected override void OnParametersSet()
    {
        FranchiseHallOfFames = Person.FranchiseHallOfFames
                                     .Filter(Sport)
                                     .Select(hof => new FranchiseHallOfFameProfileModel(hof))
                                     .ToArray();
    }
}
