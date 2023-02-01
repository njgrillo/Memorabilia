namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pucks;

public partial class PuckEditor : MemorabiliaItem<SavePuckViewModel>
{
    [Inject]
    public PuckValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPuck(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SavePuckViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SavePuck.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
