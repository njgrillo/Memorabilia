namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bookplates;

public partial class BookplateEditor : MemorabiliaItem<SaveBookplateViewModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new SaveBookplateViewModel(await QueryRouter.Send(new GetBookplate(MemorabiliaId)));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBookplate.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
