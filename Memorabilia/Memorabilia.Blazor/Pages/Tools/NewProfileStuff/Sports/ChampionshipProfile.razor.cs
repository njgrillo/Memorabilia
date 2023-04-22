namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class ChampionshipProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private ChampionshipProfileViewModel[] Championships = Array.Empty<ChampionshipProfileViewModel>();

    protected override void OnParametersSet()
    {
        Championships = Person.Teams
                              .Championships(Sport)
                              .Select(championship => new ChampionshipProfileViewModel(championship))
                              .ToArray();
    }
}
