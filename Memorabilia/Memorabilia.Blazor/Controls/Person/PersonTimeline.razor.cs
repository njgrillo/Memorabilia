#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonTimeline : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public EditModeType EditMode { get; set; } = EditModeType.Add;

    [Parameter]
    public Severity PersonAccoladeEditAlertSeverity { get; set; } = Severity.Info;

    [Parameter]
    public string PersonAccoladeEditAlertTitle { get; set; }

    [Parameter]
    public Color PersonAccoladeEditColor { get; set; } = Color.Info;

    [Parameter]
    public Severity PersonEditAlertSeverity { get; set; } = Severity.Info;

    [Parameter]
    public string PersonEditAlertTitle { get; set; }

    [Parameter]
    public Color PersonEditColor { get; set; } = Color.Info;

    [Parameter]
    public Severity PersonHallOfFameEditAlertSeverity { get; set; } = Severity.Info;

    [Parameter]
    public string PersonHallOfFameEditAlertTitle { get; set; }

    [Parameter]
    public Color PersonHallOfFameEditColor { get; set; } = Color.Info;

    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public Severity PersonImageEditAlertSeverity { get; set; } = Severity.Info;

    [Parameter]
    public string PersonImageEditAlertTitle { get; set; }

    [Parameter]
    public Color PersonImageEditColor { get; set; } = Color.Info;

    [Parameter]
    public Severity PersonOccupationEditAlertSeverity { get; set; } = Severity.Info;

    [Parameter]
    public string PersonOccupationEditAlertTitle { get; set; }

    [Parameter]
    public Color PersonOccupationEditColor { get; set; } = Color.Info;

    [Parameter]
    public Severity PersonSportServiceEditAlertSeverity { get; set; } = Severity.Info;

    [Parameter]
    public string PersonSportServiceEditAlertTitle { get; set; }

    [Parameter]
    public Color PersonSportServiceEditColor { get; set; } = Color.Info;

    [Parameter]
    public PersonStep PersonStep { get; set; }

    [Parameter]
    public Severity PersonTeamEditAlertSeverity { get; set; } = Severity.Info;

    [Parameter]
    public string PersonTeamEditAlertTitle { get; set; }

    [Parameter]
    public Color PersonTeamEditColor { get; set; } = Color.Info;

    private string _mudAlertClass;

    protected override void OnInitialized()
    {
        _mudAlertClass = PersonId > 0 ? "can-click" : string.Empty;

        PersonAccoladeEditAlertTitle = PersonStep.Accolade.Name;
        PersonEditAlertTitle = PersonStep.Person.Name;
        PersonHallOfFameEditAlertTitle = PersonStep.HallOfFame.Name;
        PersonImageEditAlertTitle = PersonStep.Image.Name;
        PersonOccupationEditAlertTitle = PersonStep.Occupation.Name;
        PersonSportServiceEditAlertTitle = PersonStep.SportService.Name;
        PersonTeamEditAlertTitle = PersonStep.Team.Name;

        if (PersonStep == PersonStep.Occupation)
        {
            PersonEditAlertSeverity = Severity.Success;
            PersonEditColor = Color.Success;
            return;
        }

        if (PersonStep == PersonStep.SportService)
        {
            PersonEditAlertSeverity = Severity.Success;
            PersonEditColor = Color.Success;
            PersonOccupationEditAlertSeverity = Severity.Success;
            PersonOccupationEditColor = Color.Success;
            return;
        }

        if (PersonStep == PersonStep.Team)
        {
            PersonEditAlertSeverity = Severity.Success;
            PersonEditColor = Color.Success;
            PersonOccupationEditAlertSeverity = Severity.Success;
            PersonOccupationEditColor = Color.Success;
            PersonSportServiceEditAlertSeverity = Severity.Success;
            PersonSportServiceEditColor = Color.Success;
            return;
        }

        if (PersonStep == PersonStep.Accolade)
        {
            PersonEditAlertSeverity = Severity.Success;
            PersonEditColor = Color.Success;
            PersonOccupationEditAlertSeverity = Severity.Success;
            PersonOccupationEditColor = Color.Success;
            PersonSportServiceEditAlertSeverity = Severity.Success;
            PersonSportServiceEditColor = Color.Success;
            PersonTeamEditAlertSeverity = Severity.Success;
            PersonTeamEditColor = Color.Success;
            return;
        }

        if (PersonStep == PersonStep.HallOfFame)
        {
            PersonAccoladeEditAlertSeverity = Severity.Success;
            PersonAccoladeEditColor = Color.Success;
            PersonEditAlertSeverity = Severity.Success;
            PersonEditColor = Color.Success;
            PersonOccupationEditAlertSeverity = Severity.Success;
            PersonOccupationEditColor = Color.Success;
            PersonSportServiceEditAlertSeverity = Severity.Success;
            PersonSportServiceEditColor = Color.Success;
            PersonTeamEditAlertSeverity = Severity.Success;
            PersonTeamEditColor = Color.Success;
            return;
        }

        if (PersonStep == PersonStep.Image)
        {
            PersonAccoladeEditAlertSeverity = Severity.Success;
            PersonAccoladeEditColor = Color.Success;
            PersonEditAlertSeverity = Severity.Success;
            PersonEditColor = Color.Success;
            PersonHallOfFameEditAlertSeverity = Severity.Success;
            PersonHallOfFameEditColor = Color.Success;
            PersonOccupationEditAlertSeverity = Severity.Success;
            PersonOccupationEditColor = Color.Success;
            PersonSportServiceEditAlertSeverity = Severity.Success;
            PersonSportServiceEditColor = Color.Success;
            PersonTeamEditAlertSeverity = Severity.Success;
            PersonTeamEditColor = Color.Success;
            return;
        }
    }

    private string GetMudAlertStyle(PersonStep personStep)
    {
        return PersonStep == personStep ? "border: 1px solid black;" : string.Empty;
    }

    private void Navigate(string item = null)
    {
        if (PersonId == 0)
            return;

        if (item.IsNullOrEmpty())
        {
            NavigationManager.NavigateTo($"People/{EditModeType.Update.Name}/{PersonId}");
            return;
        }

        NavigationManager.NavigateTo($"People/{item}/{EditModeType.Update.Name}/{PersonId}");
    }
}
