namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class SportHallOfFameProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private HallOfFameProfileViewModel[] HallOfFames = Array.Empty<HallOfFameProfileViewModel>();

    protected override void OnParametersSet()
    {
        HallOfFames = Person.HallOfFames
                            .Filter(Sport)
                            .Select(hof => new HallOfFameProfileViewModel(hof))
                            .ToArray();
    }
}
