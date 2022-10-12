namespace Memorabilia.Blazor.Pages.MemorabiliaItems.FirstDayCovers;

public partial class FirstDayCoverEditor : MemorabiliaItem<SaveFirstDayCoverViewModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new SaveFirstDayCoverViewModel(await QueryRouter.Send(new GetFirstDayCover.Query(MemorabiliaId)));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveFirstDayCover.Command(ViewModel));
    }

    private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
    {
        ViewModel.SportIds = sportIds.ToList();
    }
}
