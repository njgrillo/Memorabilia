namespace Memorabilia.Blazor.Pages.Autograph.Spots;

public partial class SpotsEditor 
    : AutographItem<SpotEditModel>
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Parameter]
    public string EncryptAutographId { get; set; }

    private string _continueNavigationPath;

    protected override async Task OnInitializedAsync()
    {
        AutographId = DataProtectorService.DecryptId(EncryptAutographId);

        Model = (await Mediator.Send(new Application.Features.Autograph.Spot.GetSpot(AutographId))).ToEditModel();

        IsLoaded = true;
    }

    protected async Task Save()
    {
        if (Model.SpotId == 0)
            return;

        await Mediator.Send(new Application.Features.Autograph.Spot.SaveSpot.Command(Model));

        _continueNavigationPath
            = $"{NavigationPath.AutographImage}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(Model.AutographId)}";
    }
}
