namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pylons;

public partial class PylonEditor : MemorabiliaItem<PylonEditModel>
{
    [Inject]
    public PylonValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new PylonEditModel(new PylonModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SavePylon.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
