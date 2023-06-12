namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Drums;

public partial class DrumEditor : MemorabiliaItem<DrumEditModel>
{
    [Inject]
    public DrumValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new DrumEditModel(new DrumModel(viewModel));
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
