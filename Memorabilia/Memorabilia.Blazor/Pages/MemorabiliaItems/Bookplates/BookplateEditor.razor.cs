namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bookplates;

public partial class BookplateEditor 
    : MemorabiliaItem<BookplateEditModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new BookplateEditModel(new BookplateModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId))));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBookplate.Command(ViewModel));
    }
}
