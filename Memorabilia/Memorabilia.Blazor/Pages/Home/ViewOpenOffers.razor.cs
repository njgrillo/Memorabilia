using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Home;

public partial class ViewOpenOffers
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public OpenOfferModel[] Items { get; set; }

    protected void Review(int offerId)
    {
        NavigationManager.NavigateTo($"{NavigationPath.Offer}/Review/{DataProtectorService.EncryptId(offerId)}");
    }
}
