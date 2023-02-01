namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Hats;

public partial class HatEditor : MemorabiliaItem<SaveHatViewModel>
{
    [Inject]
    public HatValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetHat(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveHatViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveHat.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
