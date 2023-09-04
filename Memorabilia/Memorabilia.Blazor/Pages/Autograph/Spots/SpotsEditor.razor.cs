namespace Memorabilia.Blazor.Pages.Autograph.Spots;

public partial class SpotsEditor 
    : AutographItem<SpotEditModel>
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Parameter]
    public string EncryptAutographId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        AutographId = DataProtectorService.DecryptId(EncryptAutographId);

        Model = (await QueryRouter.Send(new Application.Features.Autograph.Spot.GetSpot(AutographId))).ToEditModel();

        Model.BackNavigationPath
            = $"Autographs/Authentications/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(AutographId)}";

        IsLoaded = true;
    }

    protected async Task Save()
    {
        if (Model.SpotId == 0)
            return;

        await CommandRouter.Send(new Application.Features.Autograph.Spot.SaveSpot.Command(Model));

        Model.ContinueNavigationPath
            = $"Autographs/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(Model.AutographId)}";
    }
}
