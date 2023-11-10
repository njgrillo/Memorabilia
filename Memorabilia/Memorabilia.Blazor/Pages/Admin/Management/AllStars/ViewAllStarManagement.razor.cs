namespace Memorabilia.Blazor.Pages.Admin.Management.AllStars;

public partial class ViewAllStarManagement
{
    [Inject]
    public IMediator Mediator { get; set; }

    private AllStarManagementModel[] _completedAllStars
        = Array.Empty<AllStarManagementModel>();

    private AllStarManagementModel[] _missingAllStars
        = Array.Empty<AllStarManagementModel>();

    private AllStarManagementModel[] _notConfiguredAllStars
        = Array.Empty<AllStarManagementModel>();

    protected override async Task OnInitializedAsync()
    {
        AllStarManagementModel[] allStarManagements 
            = (await Mediator.Send(new GetAllAllStarManagements()))
                .OrderBy(allStarManagement => allStarManagement.SportLeagueLevel.Name)
                .ThenByDescending(allStarManagement => allStarManagement.Year)
                .ToArray();

        _completedAllStars = allStarManagements.Where(allStarManagement => allStarManagement.IsConfigured && !allStarManagement.NumberOfAllStarsDoesntMatch)
                                               .ToArray();

        _missingAllStars = allStarManagements.Where(allStarManagement => allStarManagement.IsConfigured && allStarManagement.NumberOfAllStarsDoesntMatch)
                                             .ToArray();

        _notConfiguredAllStars = allStarManagements.Where(allStarManagement => !allStarManagement.IsConfigured)
                                                   .ToArray();

        StateHasChanged();
    }
}
