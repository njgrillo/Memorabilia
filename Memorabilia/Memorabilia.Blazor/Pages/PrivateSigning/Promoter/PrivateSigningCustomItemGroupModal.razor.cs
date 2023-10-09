namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class PrivateSigningCustomItemGroupModal
{
    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningCustomItemTypeGroupEditModel CustomItemTypeGroup { get; set; }
        = new();

    public void Add()
    {

    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public void Update()
    {

    }
}
