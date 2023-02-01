namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Cards;

public partial class CardEditor : MemorabiliaItem<SaveCardViewModel>
{
    [Inject]
    public CardValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetCard(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveCardViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveCard.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
