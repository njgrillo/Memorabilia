namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Drums;

public partial class DrumEditor : MemorabiliaItem<SaveDrumViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetDrum(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveDrumViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveDrum.Command(ViewModel));
    }
}
