namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pants;

public partial class PantEditor : MemorabiliaItem<SavePantViewModel>
{
    [Inject]
    public PantValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPant(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SavePantViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SavePant.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
