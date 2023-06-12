namespace Memorabilia.Blazor.Pages.MemorabiliaItems.CerealBoxes;

public partial class CerealBoxEditor : MemorabiliaItem<CerealBoxEditModel>
{
    [Inject]
    public CerealBoxValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new CerealBoxEditModel(new CerealBoxModel(viewModel));
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
