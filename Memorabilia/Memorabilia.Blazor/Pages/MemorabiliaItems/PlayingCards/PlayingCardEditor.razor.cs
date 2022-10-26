namespace Memorabilia.Blazor.Pages.MemorabiliaItems.PlayingCards;

public partial class PlayingCardEditor : MemorabiliaItem<SavePlayingCardViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPlayingCard(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SavePlayingCardViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePlayingCard.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
