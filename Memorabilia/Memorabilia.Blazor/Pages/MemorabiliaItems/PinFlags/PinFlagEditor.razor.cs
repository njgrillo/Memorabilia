namespace Memorabilia.Blazor.Pages.MemorabiliaItems.PinFlags;

public partial class PinFlagEditor : MemorabiliaItem<SavePinFlagViewModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new SavePinFlagViewModel(await QueryRouter.Send(new GetPinFlag(MemorabiliaId)));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePinFlag.Command(ViewModel));
    }
}
