namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Trunks;

public partial class TrunkEditor : MemorabiliaItem<TrunkEditModel>
{
    [Inject]
    public TrunkValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new TrunkEditModel(new TrunkModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveTrunk.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
