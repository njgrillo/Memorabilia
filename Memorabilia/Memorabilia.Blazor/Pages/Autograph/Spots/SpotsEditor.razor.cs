namespace Memorabilia.Blazor.Pages.Autograph.Spots;

public partial class SpotsEditor 
    : AutographItem<SpotEditModel>
{
    [Parameter]
    public string UploadPath { get; set; }

    protected async Task OnLoad()
    {
        Model = (await QueryRouter.Send(new Application.Features.Autograph.Spot.GetSpot(AutographId))).ToEditModel();
    }

    protected async Task OnSave()
    {
        if (Model.SpotId == 0)
            return;

        await CommandRouter.Send(new Application.Features.Autograph.Spot.SaveSpot.Command(Model));
    }
}
