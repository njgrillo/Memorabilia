namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pylons;

public partial class PylonEditor : MemorabiliaItem<SavePylonViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPylon.Query(MemorabiliaId));

        if (viewModel.Size == null)
            return;

        ViewModel = new SavePylonViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePylon.Command(ViewModel));
    }

    private void SelectedTeamChanged(SaveTeamViewModel team)
    {
        ViewModel.Team = team;
    }
}
