namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Gloves;

public partial class GloveEditor : MemorabiliaItem<SaveGloveViewModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new SaveGloveViewModel(await QueryRouter.Send(new GetGlove(MemorabiliaId)));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveGlove.Command(ViewModel));
    }
}
