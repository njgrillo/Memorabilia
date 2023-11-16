namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonRecentOccupationSelector
{
    [Parameter]
    public EventCallback<RecentPersonOccupationsModel> OnRecentOccupationChange { get; set; }

    [Parameter]
    public RecentPersonOccupationsModel[] RecentOccupations { get; set; } 
        = [];

    private async void Select(RecentPersonOccupationsModel recentOccupation)
    {
        await OnRecentOccupationChange.InvokeAsync(recentOccupation);
    }
}
