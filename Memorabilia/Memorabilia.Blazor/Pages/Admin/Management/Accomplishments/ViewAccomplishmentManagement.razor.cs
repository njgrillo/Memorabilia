namespace Memorabilia.Blazor.Pages.Admin.Management.Accomplishments;

public partial class ViewAccomplishmentManagement
{
    [Inject]
    public IMediator Mediator { get; set; }

    private AccomplishmentManagementModel[] _completedAccomplishments
        = Array.Empty<AccomplishmentManagementModel>();

    private AccomplishmentManagementModel[] _missingPersons
        = Array.Empty<AccomplishmentManagementModel>();

    private AccomplishmentManagementModel[] _missingYears
        = Array.Empty<AccomplishmentManagementModel>();

    private AccomplishmentManagementModel[] _notConfigured
        = Array.Empty<AccomplishmentManagementModel>();

    protected override async Task OnInitializedAsync()
    {
        AccomplishmentManagementModel[] accomplishmentManagements 
            = (await Mediator.Send(new GetAllAccomplishmentManagements()))
                .OrderBy(accomplishmentManagement => accomplishmentManagement.AccomplishmentType.Name)
                .ToArray();

        _completedAccomplishments 
            = accomplishmentManagements.Where(accomplishmentManagement => accomplishmentManagement.IsConfigured && 
                                                                          ((accomplishmentManagement.BeginYear.HasValue && !accomplishmentManagement.HasMissingYears) || (accomplishmentManagement.Year.HasValue && !accomplishmentManagement.NumberOfWinnersDoesntMatch) || (!accomplishmentManagement.BeginYear.HasValue && !accomplishmentManagement.Year.HasValue && !accomplishmentManagement.NumberOfWinnersDoesntMatch)))
                                       .ToArray();

        _missingPersons = accomplishmentManagements.Where(awardManagement => awardManagement.IsConfigured &&
                                                                             awardManagement.NumberOfWinnersDoesntMatch)
                                                   .ToArray();

        _missingYears = accomplishmentManagements.Where(awardManagement => awardManagement.IsConfigured && 
                                                                           awardManagement.HasMissingYears)
                                                 .ToArray();

        _notConfigured = accomplishmentManagements.Where(awardManagement => !awardManagement.IsConfigured)
                                                  .ToArray();
    }
}
