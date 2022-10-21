namespace Memorabilia.Blazor.Pages.MemorabiliaItems.IndexCards;

public partial class IndexCardEditor : MemorabiliaItem<SaveIndexCardViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetIndexCard(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SaveIndexCardViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveIndexCard.Command(ViewModel));
    }
}
