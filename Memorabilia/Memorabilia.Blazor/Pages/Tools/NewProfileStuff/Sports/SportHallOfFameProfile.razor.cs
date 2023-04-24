namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class SportHallOfFameProfile : SportProfile
{
    private HallOfFameProfileViewModel[] HallOfFames = Array.Empty<HallOfFameProfileViewModel>();

    protected override void OnParametersSet()
    {
        HallOfFames = Person.HallOfFames
                            .Filter(Sport)
                            .Select(hof => new HallOfFameProfileViewModel(hof))
                            .ToArray();
    }
}
