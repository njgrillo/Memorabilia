namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Cards;

public partial class CardEditor : MemorabiliaItem<SaveCardViewModel>
{ 
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetCard(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveCardViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveCard.Command(ViewModel));
    }
}
