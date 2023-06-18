namespace Memorabilia.Blazor.Pages.Autograph.Spots;

public partial class SpotsEditor 
    : AutographItem<SpotEditModel>
{
    protected override async Task OnInitializedAsync()
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
