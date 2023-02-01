namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bobbleheads;

public partial class BobbleheadEditor : MemorabiliaItem<SaveBobbleheadViewModel>
{
    [Inject]
    public BobbleheadValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetBobblehead(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBobbleheadViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveBobblehead.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
