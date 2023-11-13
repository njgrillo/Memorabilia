namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Books;

public partial class EditBook 
    : MemorabiliaItem<BookEditModel>
{
    [Inject]
    public BookValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        EditModel = new(new BookModel(await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId))))
        {
            MemorabiliaId = MemorabiliaId
        };
    }

    protected async Task OnSave()
    {
        var command = new SaveBook.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);
    }
}
