namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonRecentOccupationSelector
{
    [Parameter]
    public EventCallback<RecentPersonOccupationsModel> OnRecentOccupationChange { get; set; }

    [Parameter]
    public RecentPersonOccupationsModel[] RecentOccupations { get; set; } 
        = Array.Empty<RecentPersonOccupationsModel>();

    private async void Select(RecentPersonOccupationsModel recentOccupation)
    {
        await OnRecentOccupationChange.InvokeAsync(recentOccupation);
    }
}
