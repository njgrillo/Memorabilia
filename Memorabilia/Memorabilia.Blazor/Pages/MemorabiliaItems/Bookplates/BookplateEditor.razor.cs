namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bookplates;

public partial class BookplateEditor 
    : MemorabiliaItem<BookplateEditModel>
{
    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        EditModel = new(new BookplateModel(await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId))))
        {
            MemorabiliaId = MemorabiliaId
        };
    }

    protected async Task OnSave()
    {
        await Mediator.Send(new SaveBookplate.Command(EditModel));
    }
}
