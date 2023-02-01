namespace Memorabilia.Blazor.Pages.MemorabiliaItems.TennisRackets;

public partial class TennisRacketEditor : MemorabiliaItem<SaveTennisRacketViewModel>
{
    [Inject]
    public TennisRacketValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetTennisRacket(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveTennisRacketViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveTennisRacket.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
