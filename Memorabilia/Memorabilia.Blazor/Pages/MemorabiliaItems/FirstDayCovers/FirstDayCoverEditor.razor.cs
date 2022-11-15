namespace Memorabilia.Blazor.Pages.MemorabiliaItems.FirstDayCovers;

public partial class FirstDayCoverEditor : MemorabiliaItem<SaveFirstDayCoverViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetFirstDayCover(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SaveFirstDayCoverViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveFirstDayCover.Command(ViewModel));
    }
}
