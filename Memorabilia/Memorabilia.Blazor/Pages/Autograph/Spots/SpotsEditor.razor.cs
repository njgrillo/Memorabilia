#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph.Spots;

public partial class SpotsEditor : ComponentBase
{
    [Parameter]
    public int AutographId { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private SaveSpotViewModel _viewModel = new ();        

    protected async Task OnLoad()
    {
        _viewModel = new SaveSpotViewModel(await QueryRouter.Send(new Application.Features.Autograph.Spot.GetSpot.Query(AutographId)).ConfigureAwait(false));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new Application.Features.Autograph.Spot.SaveSpot.Command(_viewModel)).ConfigureAwait(false);
    }
}
