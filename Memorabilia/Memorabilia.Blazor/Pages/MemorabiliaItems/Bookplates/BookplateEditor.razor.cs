namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bookplates;

public partial class BookplateEditor 
    : MemorabiliaItem<BookplateEditModel>
{
    protected override async Task OnInitializedAsync()
    {
        EditModel = new(new BookplateModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId))));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBookplate.Command(EditModel));
    }
}
