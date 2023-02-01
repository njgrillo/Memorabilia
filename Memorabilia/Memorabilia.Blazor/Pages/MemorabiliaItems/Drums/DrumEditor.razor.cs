namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Drums;

public partial class DrumEditor : MemorabiliaItem<SaveDrumViewModel>
{
    [Inject]
    public DrumValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetDrum(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveDrumViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveDrum.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
