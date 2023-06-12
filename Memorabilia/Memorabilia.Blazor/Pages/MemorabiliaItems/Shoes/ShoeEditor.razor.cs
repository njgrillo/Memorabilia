namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Shoes;

public partial class ShoeEditor : MemorabiliaItem<ShoeEditModel>
{
    [Inject]
    public ShoeValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new ShoeEditModel(new ShoeModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveShoe.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
