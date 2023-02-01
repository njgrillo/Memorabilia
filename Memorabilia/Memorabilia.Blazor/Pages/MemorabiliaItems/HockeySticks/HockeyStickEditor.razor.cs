namespace Memorabilia.Blazor.Pages.MemorabiliaItems.HockeySticks;

public partial class HockeyStickEditor : MemorabiliaItem<SaveHockeyStickViewModel>
{
    [Inject]
    public HockeyStickValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetHockeyStick(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveHockeyStickViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveHockeyStick.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
