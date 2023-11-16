using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaItemTimeline : ComponentBase
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public EditModeType EditMode { get; set; }
        = EditModeType.Add;

    [Parameter]
    public string ItemTypeName { get; set; }

    [Parameter]
    public Severity MemorabiliaEditDetailAlertSeverity { get; set; } 
        = Severity.Info;

    [Parameter]
    public string MemorabiliaEditDetailAlertTitle { get; set; }

    [Parameter]
    public Color MemorabiliaEditDetailColor { get; set; } 
        = Color.Info;

    [Parameter]
    public Severity MemorabiliaEditImageAlertSeverity { get; set; } 
        = Severity.Info;

    [Parameter]
    public string MemorabiliaEditImageAlertTitle { get; set; }

    [Parameter]
    public Color MemorabiliaEditImageColor { get; set; } 
        = Color.Info;

    [Parameter]
    public Severity MemorabiliaEditItemAlertSeverity { get; set; } 
        = Severity.Info;

    [Parameter]
    public string MemorabiliaEditItemAlertTitle { get; set; }

    [Parameter]
    public Color MemorabiliaEditItemColor { get; set; } 
        = Color.Info;

    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public MemorabiliaItemStep MemorabiliaItemStep { get; set; }

    private string _mudAlertClass;

    protected override void OnInitialized()
    {
        _mudAlertClass = MemorabiliaId > 0 
            ? "can-click" 
            : string.Empty;

        MemorabiliaEditDetailAlertTitle = MemorabiliaItemStep.Detail.Name;
        MemorabiliaEditImageAlertTitle = MemorabiliaItemStep.Image.Name;
        MemorabiliaEditItemAlertTitle = MemorabiliaItemStep.Item.Name;

        if (MemorabiliaItemStep == MemorabiliaItemStep.Detail)
        {
            MemorabiliaEditItemAlertSeverity = Severity.Success;
            MemorabiliaEditItemColor = Color.Success;
            return;
        }

        if (MemorabiliaItemStep == MemorabiliaItemStep.Image)
        {
            MemorabiliaEditDetailAlertSeverity = Severity.Success;
            MemorabiliaEditDetailColor = Color.Success;
            MemorabiliaEditItemAlertSeverity = Severity.Success;
            MemorabiliaEditItemColor = Color.Success;
            return;
        }
    }

    private string GetMudAlertStyle(MemorabiliaItemStep memorabiliaItemStep)
        => MemorabiliaItemStep == memorabiliaItemStep 
            ? "border: 1px solid black;" 
            : string.Empty;

    private void Navigate(string item = null)
    {
        if (MemorabiliaId == 0)
            return;

        if (item.IsNullOrEmpty())
        {
            NavigationManager.NavigateTo($"{NavigationPath.Memorabilia}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}");
            return;
        }

        NavigationManager.NavigateTo($"{NavigationPath.Memorabilia}/{item}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}");
    }
}
