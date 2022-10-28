namespace Memorabilia.Blazor.Pages.MemorabiliaItems.JerseyNumbers;

public partial class JerseyNumberEditor : MemorabiliaItem<SaveJerseyNumberViewModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new SaveJerseyNumberViewModel(await QueryRouter.Send(new GetJerseyNumber(MemorabiliaId)));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveJerseyNumber.Command(ViewModel));
    }
}
