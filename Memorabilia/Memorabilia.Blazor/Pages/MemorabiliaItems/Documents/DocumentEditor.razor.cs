namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Documents;

public partial class DocumentEditor : MemorabiliaItem<DocumentEditModel>
{
    [Inject]
    public DocumentValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new DocumentEditModel(new DocumentModel(viewModel));
    }

    protected async Task OnSave()
    {
        var command = new SaveDocument.Command(ViewModel);

        ViewModel.ValidationResult = Validator.Validate(command);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        ViewModel.SavedSuccessfully = true;
    }
}
