namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bats;

public partial class BatEditor : MemorabiliaItem<SaveBatViewModel>
{
    [Inject]
    public BatValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetBat(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBatViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveBat.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
