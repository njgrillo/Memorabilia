namespace Memorabilia.Blazor.Pages.MemorabiliaItems.PinFlags;

public partial class PinFlagEditor : MemorabiliaItem<SavePinFlagViewModel>
{
    [Inject]
    public PinFlagValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        ViewModel = new SavePinFlagViewModel(await QueryRouter.Send(new GetPinFlag(MemorabiliaId)));
    }

    protected async Task OnSave()
    {
        var command = new SavePinFlag.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
