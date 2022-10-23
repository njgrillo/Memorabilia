namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Books;

public partial class BookEditor : MemorabiliaItem<SaveBookViewModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new SaveBookViewModel(await QueryRouter.Send(new GetBook(MemorabiliaId)));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBook.Command(ViewModel));
    }
}
