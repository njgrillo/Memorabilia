namespace Memorabilia.Blazor.Pages.Home;

public partial class OpenProposedTrades
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public OpenProposedTradeModel[] Items { get; set; }

    protected void Review(int proposeTradeId)
    {
        NavigationManager.NavigateTo($"{NavigationPath.ProposeTrade}/Review/{DataProtectorService.EncryptId(proposeTradeId)}");
    }
}
