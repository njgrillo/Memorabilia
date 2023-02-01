namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Gloves;

public partial class GloveEditor : MemorabiliaItem<SaveGloveViewModel>
{
    [Inject]
    public GloveValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetGlove(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveGloveViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveGlove.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
