namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pylons;

public partial class PylonEditor : MemorabiliaItem<SavePylonViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPylon(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SavePylonViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePylon.Command(ViewModel));
    }
}
