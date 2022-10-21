namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Documents;

public partial class DocumentEditor : MemorabiliaItem<SaveDocumentViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetDocument(MemorabiliaId));

        ViewModel = new SaveDocumentViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveDocument.Command(ViewModel));
    }
}
