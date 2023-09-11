namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Documents;

public partial class DocumentEditor 
    : MemorabiliaItem<DocumentEditModel>
{
    [Inject]
    public DocumentValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);
        EditModel.MemorabiliaId = MemorabiliaId;

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        if (memorabilia.Size == null)
            return;

        EditModel = new(new DocumentModel(memorabilia));
    }

    protected async Task OnSave()
    {
        var command = new SaveDocument.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);
    }
}
