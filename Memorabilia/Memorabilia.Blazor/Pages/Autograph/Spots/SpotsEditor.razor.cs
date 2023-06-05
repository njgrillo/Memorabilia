namespace Memorabilia.Blazor.Pages.Autograph.Spots;

public partial class SpotsEditor : AutographItem<SpotEditModel>
{
    [Parameter]
    public string UploadPath { get; set; }

    protected async Task OnLoad()
    {
        ViewModel = new SpotEditModel(new SpotModel(await QueryRouter.Send(new Application.Features.Autograph.Spot.GetSpot(AutographId))));
    }

    protected async Task OnSave()
    {
        if (ViewModel.SpotId == 0)
            return;

        await CommandRouter.Send(new Application.Features.Autograph.Spot.SaveSpot.Command(ViewModel));
    }
}
