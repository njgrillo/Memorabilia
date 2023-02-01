namespace Memorabilia.Blazor.Pages.MemorabiliaItems.PlayingCards;

public partial class PlayingCardEditor : MemorabiliaItem<SavePlayingCardViewModel>
{
    [Inject]
    public PlayingCardValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPlayingCard(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SavePlayingCardViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SavePlayingCard.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
