namespace Memorabilia.Blazor.Pages.Admin.Management.Awards;

public partial class ViewAwardManagement
{    
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private AwardManagementModel[] _completedAwards 
        = Array.Empty<AwardManagementModel>();

    private AwardManagementModel[] _missingPersonAwards
        = Array.Empty<AwardManagementModel>();

    private AwardManagementModel[] _missingYearsAwards
        = Array.Empty<AwardManagementModel>();

    private AwardManagementModel[] _notConfiguredAwards
        = Array.Empty<AwardManagementModel>();

    protected override async Task OnInitializedAsync()
    {
        AwardManagementModel[] awardManagements = (await QueryRouter.Send(new GetAllAwardManagements()))
            .OrderBy(awardManagement => awardManagement.AwardType.Name)
            .ToArray();

        _completedAwards = awardManagements.Where(awardManagement => awardManagement.IsConfigured && !awardManagement.HasMissingYears)
                                           .ToArray();

        _missingPersonAwards = awardManagements.Where(awardManagement => awardManagement.IsConfigured && awardManagement.HasMissingYears)
                                               .ToArray();

        _missingYearsAwards = awardManagements.Where(awardManagement => awardManagement.IsConfigured && awardManagement.HasMissingYears)
                                              .ToArray();

        _notConfiguredAwards = awardManagements.Where(awardManagement => !awardManagement.IsConfigured)
                                               .ToArray();
    }
}
