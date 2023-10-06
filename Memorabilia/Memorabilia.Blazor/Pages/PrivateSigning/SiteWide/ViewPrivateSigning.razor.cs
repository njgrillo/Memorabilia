namespace Memorabilia.Blazor.Pages.PrivateSigning.SiteWide;

public partial class ViewPrivateSigning
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public string EncryptPrivateSigningId { get; set; }

    protected PrivateSigningModel Model { get; set; }
        = new();

    protected int PrivateSigningId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        PrivateSigningId = DataProtectorService.DecryptId(EncryptPrivateSigningId);

        Model = new(await QueryRouter.Send(new GetPrivateSigning(PrivateSigningId)));
    }
}
