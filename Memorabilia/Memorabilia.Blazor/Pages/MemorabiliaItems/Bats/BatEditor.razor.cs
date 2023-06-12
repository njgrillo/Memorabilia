namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bats;

public partial class BatEditor : MemorabiliaItem<BatEditModel>
{
    [Inject]
    public BatValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new BatEditModel(new BatModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveBat.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
