namespace Memorabilia.Blazor.Pages.Admin.Management.Accomplishments;

public partial class ViewAccomplishmentManagement
{
    [Inject]
    public IMediator Mediator { get; set; }

    private AccomplishmentManagementModel[] _completedAccomplishments
        = [];    

    private AccomplishmentManagementModel[] _missingOccurrences
        = [];

    private AccomplishmentManagementModel[] _missingYears
        = [];

    private AccomplishmentManagementModel[] _notConfigured
        = [];

    protected override async Task OnInitializedAsync()
    {
        AccomplishmentManagementModel[] accomplishmentManagements 
            = (await Mediator.Send(new GetAllAccomplishmentManagements()))
                .OrderBy(accomplishmentManagement => accomplishmentManagement.AccomplishmentType.Name)
                .ToArray();

        SetNotConfigured(accomplishmentManagements);
        SetMissingOccurrences(accomplishmentManagements);  
        SetMissingYears(accomplishmentManagements);
        SetCompletedOccurrences(accomplishmentManagements);

        StateHasChanged();
    }

    public void SetCompletedOccurrences(AccomplishmentManagementModel[] accomplishmentManagements)
    {
        _completedAccomplishments
            = accomplishmentManagements.Where(accomplishmentManagement => 
                accomplishmentManagement.IgnoreManagement ||
                (accomplishmentManagement.IsConfigured &&
                 !accomplishmentManagement.HasMissingNumberOfOccurrences &&
                 !accomplishmentManagement.HasMissingYears))
                                       .ToArray();
    }

    public void SetMissingOccurrences(AccomplishmentManagementModel[] accomplishmentManagements)
    {
        _missingOccurrences 
            = accomplishmentManagements.Where(accomplishmentManagement => accomplishmentManagement.IsConfigured &&
                                              !accomplishmentManagement.IgnoreManagement &&
                                              accomplishmentManagement.HasMissingNumberOfOccurrences)
                                       .ToArray();
    }

    public void SetMissingYears(AccomplishmentManagementModel[] accomplishmentManagements)
    {
        _missingYears 
            = accomplishmentManagements.Where(accomplishmentManagement => accomplishmentManagement.IsConfigured &&
                                                                          !accomplishmentManagement.IgnoreManagement &&
                                                                          accomplishmentManagement.HasMissingYears)
                                       .ToArray();
    }

    public void SetNotConfigured(AccomplishmentManagementModel[] accomplishmentManagements)
    {
        _notConfigured 
            = accomplishmentManagements.Where(accomplishmentManagement => !accomplishmentManagement.IsConfigured && 
                                              !accomplishmentManagement.IgnoreManagement)
                                       .ToArray();
    }
}
