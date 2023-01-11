namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonRecentOccupationSelector
{
    [Parameter]
    public EventCallback<RecentPersonOccupationsViewModel> OnRecentOccupationChange { get; set; }

    [Parameter]
    public RecentPersonOccupationsViewModel[] RecentOccupations { get; set; } 
        = Array.Empty<RecentPersonOccupationsViewModel>();

    private async void Select(RecentPersonOccupationsViewModel recentOccupation)
    {
        await OnRecentOccupationChange.InvokeAsync(recentOccupation);
    }
}
