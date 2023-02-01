namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Shirts;

public partial class ShirtEditor : MemorabiliaItem<SaveShirtViewModel>
{
    [Inject]
    public ShirtValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetShirt(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveShirtViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveShirt.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
