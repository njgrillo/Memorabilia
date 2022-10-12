namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bammers;

public partial class BammerEditor : MemorabiliaItem<SaveBammerViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetBammer.Query(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBammerViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBammer.Command(ViewModel));
    }
}
