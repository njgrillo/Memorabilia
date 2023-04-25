namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class ChampionshipProfile : SportProfile
{
    private ChampionshipProfileViewModel[] Championships = Array.Empty<ChampionshipProfileViewModel>();

    protected override void OnParametersSet()
    {
        Championships = Person.Teams
                              .Championships(Sport, OccupationType)
                              .Select(championship => new ChampionshipProfileViewModel(championship))
                              .ToArray();
    }
}
