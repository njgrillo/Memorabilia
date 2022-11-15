namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Gloves;

public partial class GloveEditor : MemorabiliaItem<SaveGloveViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetGlove(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveGloveViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveGlove.Command(ViewModel));
    }
}
