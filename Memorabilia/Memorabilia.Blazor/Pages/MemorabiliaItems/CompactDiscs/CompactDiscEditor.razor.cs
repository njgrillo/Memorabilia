namespace Memorabilia.Blazor.Pages.MemorabiliaItems.CompactDiscs;

public partial class CompactDiscEditor : MemorabiliaItem<SaveCompactDiscViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetCompactDisc(MemorabiliaId));

        ViewModel = new SaveCompactDiscViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveCompactDisc.Command(ViewModel));
    }
}
