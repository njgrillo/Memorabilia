namespace Memorabilia.Blazor.Pages.MemorabiliaItems.PinFlags;

public partial class PinFlagEditor : MemorabiliaItem<SavePinFlagViewModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new SavePinFlagViewModel(await QueryRouter.Send(new GetPinFlag.Query(MemorabiliaId)));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePinFlag.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }
}
