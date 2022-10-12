namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Soccerballs;

public partial class SoccerballEditor : MemorabiliaItem<SaveSoccerballViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetSoccerball.Query(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveSoccerballViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveSoccerball.Command(ViewModel));
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }

    private void SelectedTeamChanged(SaveTeamViewModel team)
    {
        ViewModel.Team = team;
    }
}
