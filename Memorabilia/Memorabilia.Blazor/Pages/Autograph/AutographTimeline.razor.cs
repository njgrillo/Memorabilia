namespace Memorabilia.Blazor.Pages.Autograph;

public partial class AutographTimeline
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public int AutographId { get; set; }

    [Parameter]
    public EditModeType EditMode { get; set; } 
        = EditModeType.Add;

    [Parameter]
    public Severity AutographAuthenticationEditAlertSeverity { get; set; } 
        = Severity.Info;

    [Parameter]
    public string AutographAuthenticationEditAlertTitle { get; set; }

    [Parameter]
    public Color AutographAuthenticationEditColor { get; set; } 
        = Color.Info;

    [Parameter]
    public Severity AutographEditAlertSeverity { get; set; } 
        = Severity.Info;

    [Parameter]
    public string AutographEditAlertTitle { get; set; }

    [Parameter]
    public Color AutographEditColor { get; set; } 
        = Color.Info;

    [Parameter]
    public Severity AutographImageEditAlertSeverity { get; set; } 
        = Severity.Info;

    [Parameter]
    public string AutographImageEditAlertTitle { get; set; }

    [Parameter]
    public Color AutographImageEditColor { get; set; } 
        = Color.Info;

    [Parameter]
    public Severity AutographInscriptionEditAlertSeverity { get; set; } 
        = Severity.Info;

    [Parameter]
    public string AutographInscriptionEditAlertTitle { get; set; }

    [Parameter]
    public Color AutographInscriptionEditColor { get; set; } 
        = Color.Info;

    [Parameter]
    public Severity AutographSpotEditAlertSeverity { get; set; } 
        = Severity.Info;

    [Parameter]
    public string AutographSpotEditAlertTitle { get; set; }

    [Parameter]
    public Color AutographSpotEditColor { get; set; } 
        = Color.Info;

    [Parameter]
    public AutographStep AutographStep { get; set; }

    [Parameter]
    public bool DisplaySpot { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    private string _mudAlertClass;

    protected override void OnInitialized()
    {
        _mudAlertClass = AutographId > 0 
            ? "can-click" 
            : string.Empty;

        AutographAuthenticationEditAlertTitle = AutographStep.Authentication.Name;
        AutographEditAlertTitle = AutographStep.Autograph.Name;
        AutographImageEditAlertTitle = AutographStep.Image.Name;
        AutographInscriptionEditAlertTitle = AutographStep.Inscription.Name;

        if (DisplaySpot)
            AutographSpotEditAlertTitle = AutographStep.Spot.Name;

        if (AutographStep == AutographStep.Inscription)
        {
            AutographEditAlertSeverity = Severity.Success;
            AutographEditColor = Color.Success;
            return;
        }

        if (AutographStep == AutographStep.Authentication)
        {
            AutographEditAlertSeverity = Severity.Success;
            AutographEditColor = Color.Success;
            AutographInscriptionEditAlertSeverity = Severity.Success;
            AutographInscriptionEditColor = Color.Success;
            return;
        }

        if (DisplaySpot && AutographStep == AutographStep.Spot)
        {
            AutographAuthenticationEditAlertSeverity = Severity.Success;
            AutographAuthenticationEditColor = Color.Success;
            AutographEditAlertSeverity = Severity.Success;
            AutographEditColor = Color.Success;
            AutographInscriptionEditAlertSeverity = Severity.Success;
            AutographInscriptionEditColor = Color.Success;
            return;
        }

        if (AutographStep == AutographStep.Image)
        {
            AutographAuthenticationEditAlertSeverity = Severity.Success;
            AutographAuthenticationEditColor = Color.Success;
            AutographEditAlertSeverity = Severity.Success;
            AutographEditColor = Color.Success;
            AutographInscriptionEditAlertSeverity = Severity.Success;
            AutographInscriptionEditColor = Color.Success;

            if (DisplaySpot)
            {
                AutographSpotEditAlertSeverity = Severity.Success;
                AutographSpotEditColor = Color.Success;
            }

            return;
        }
    }

    private string GetMudAlertStyle(AutographStep autographStep)
        => AutographStep == autographStep 
            ? "border: 1px solid black;" 
            : string.Empty;

    private void Navigate(string item = null)
    {
        if (AutographId == 0)
            return;

        string url = !item.IsNullOrEmpty()
            ? $"{NavigationPath.Autographs}/{item}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(AutographId)}"
            : $"{NavigationPath.Autographs}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}/{DataProtectorService.EncryptId(AutographId)}";

        NavigationManager.NavigateTo(url);
    }
}
