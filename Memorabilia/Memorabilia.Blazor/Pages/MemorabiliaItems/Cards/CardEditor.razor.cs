namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Cards;

public partial class CardEditor : MemorabiliaItem<CardEditModel>
{
    [Inject]
    public CardValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new CardEditModel(new CardModel(viewModel));
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
