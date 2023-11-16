namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class SportHallOfFameProfile : SportProfile
{
    private HallOfFameProfileModel[] HallOfFames 
        = [];

    protected override void OnParametersSet()
    {
        HallOfFames = Person.HallOfFames
                            .Filter(Sport)
                            .Select(hof => new HallOfFameProfileModel(hof))
                            .ToArray();
    }
}
