namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class PrivateSigningEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public string EncryptPrivateSigningId { get; set; }

    protected PrivateSigningEditModel EditModel { get; set; }
        = new();

    protected int PrivateSigningId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (EncryptPrivateSigningId.IsNullOrEmpty())
        {
            EditModel = new(ApplicationStateService.CurrentUser);
            return;
        }            

        PrivateSigningId = DataProtectorService.DecryptId(EncryptPrivateSigningId);

        Entity.PrivateSigning privateSigning 
            = await QueryRouter.Send(new GetPrivateSigning(PrivateSigningId));

        EditModel = new(privateSigning);
    }    
}
