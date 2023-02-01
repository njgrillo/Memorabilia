namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Lithographs;

public partial class LithographEditor : MemorabiliaItem<SaveLithographViewModel>
{
    [Inject]
    public LithographValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetLithograph(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveLithographViewModel(viewModel);
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
