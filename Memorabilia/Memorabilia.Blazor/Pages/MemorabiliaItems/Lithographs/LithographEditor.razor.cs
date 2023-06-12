namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Lithographs;

public partial class LithographEditor : MemorabiliaItem<LithographEditModel>
{
    [Inject]
    public LithographValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new LithographEditModel(new LithographModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveLithograph.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
