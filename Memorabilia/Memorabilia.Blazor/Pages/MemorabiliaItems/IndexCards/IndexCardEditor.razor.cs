namespace Memorabilia.Blazor.Pages.MemorabiliaItems.IndexCards;

public partial class IndexCardEditor : MemorabiliaItem<IndexCardEditModel>
{
    [Inject]
    public IndexCardValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new IndexCardEditModel(new IndexCardModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveIndexCard.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
