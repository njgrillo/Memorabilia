namespace Memorabilia.Blazor.Pages.MemorabiliaItems.HeadBands;

public partial class HeadBandEditor : MemorabiliaItem<SaveHeadBandViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetHeadBand(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveHeadBandViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveHeadBand.Command(ViewModel));
    }
}
