namespace Memorabilia.Blazor.Pages.MemorabiliaItems.CompactDiscs;

public partial class CompactDiscEditor : MemorabiliaItem<CompactDiscEditModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        ViewModel = new CompactDiscEditModel(new CompactDiscModel(viewModel));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveCompactDisc.Command(ViewModel));
    }
}
