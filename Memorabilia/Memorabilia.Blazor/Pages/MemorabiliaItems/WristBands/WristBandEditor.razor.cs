namespace Memorabilia.Blazor.Pages.MemorabiliaItems.WristBands;

public partial class WristBandEditor : MemorabiliaItem<SaveWristBandViewModel>
{
    [Inject]
    public WristBandValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetWristBand(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveWristBandViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveWristBand.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
