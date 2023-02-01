namespace Memorabilia.Blazor.Pages.MemorabiliaItems.CerealBoxes;

public partial class CerealBoxEditor : MemorabiliaItem<SaveCerealBoxViewModel>
{
    [Inject]
    public CerealBoxValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetCerealBox(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveCerealBoxViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        var command = new SaveCerealBox.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true; 
    }
}
