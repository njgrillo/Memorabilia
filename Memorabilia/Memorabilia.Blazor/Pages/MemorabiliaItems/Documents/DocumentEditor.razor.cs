﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Documents;

public partial class DocumentEditor : MemorabiliaItem<SaveDocumentViewModel>
{
    [Inject]
    public DocumentValidator Validator { get; set; }

    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetDocument(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SaveDocumentViewModel(viewModel);
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
