#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph.Spots;

public partial class SpotsEditor : AutographItem<SaveSpotViewModel>
{
    [Parameter]
    public string UploadPath { get; set; }

    protected async Task OnLoad()
    {
        ViewModel = new SaveSpotViewModel(await QueryRouter.Send(new Application.Features.Autograph.Spot.GetSpot.Query(AutographId)));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new Application.Features.Autograph.Spot.SaveSpot.Command(ViewModel));
    }
}
