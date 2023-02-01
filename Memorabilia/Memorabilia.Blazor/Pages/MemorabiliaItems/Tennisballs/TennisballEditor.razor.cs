namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Tennisballs;

public partial class TennisballEditor : MemorabiliaItem<SaveTennisballViewModel>
{
    [Inject]
    public TennisballValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetTennisball(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveTennisballViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveTennisball.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
