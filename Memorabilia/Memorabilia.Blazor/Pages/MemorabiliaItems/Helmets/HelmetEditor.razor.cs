namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Helmets;

public partial class HelmetEditor : MemorabiliaItem<SaveHelmetViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetHelmet.Query(MemorabiliaId));

        if (viewModel.Brand == null)
        {
            SetDefaults();
            return;
        }

        ViewModel = new SaveHelmetViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveHelmet.Command(ViewModel));
    }

    private void SelectedSportIdsChanged(IEnumerable<int> sportIds)
    {
        ViewModel.SportIds = sportIds.ToList();
    }

    private void SetDefaults()
    {
        ViewModel.GameStyleTypeId = GameStyleType.None.Id;
    }
}
