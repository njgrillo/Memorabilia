namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bammers;

public partial class BammerEditor : MemorabiliaItem<SaveBammerViewModel>
{
    [Inject]
    public BammerValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetBammer(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBammerViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveBammer.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
