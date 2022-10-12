namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Bats;

public partial class BatEditor : MemorabiliaItem<SaveBatViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetBat.Query(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SaveBatViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBat.Command(ViewModel));
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
