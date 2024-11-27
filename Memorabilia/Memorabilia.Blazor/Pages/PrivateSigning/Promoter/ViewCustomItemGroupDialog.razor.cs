namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class ViewCustomItemGroupDialog
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int PrivateSigningCustomItemGroupId { get; set; }    

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    protected List<PrivateSigningCustomItemGroupModel> CustomItemGroups { get; set; }
        = [];

    protected override async Task OnParametersSetAsync()
    {
        if (PrivateSigningCustomItemGroupId == 0)
            return;

        Entity.PrivateSigningCustomItemGroup privateSigningCustomItemGroup 
            = await Mediator.Send(new GetPrivateSigningCustomItemGroup(PrivateSigningCustomItemGroupId));

        CustomItemGroups =
        [
            new PrivateSigningCustomItemGroupModel(privateSigningCustomItemGroup)
        ];
    }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
