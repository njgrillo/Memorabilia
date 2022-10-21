namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Pants;

public partial class PantEditor : MemorabiliaItem<SavePantViewModel>
{
    protected async Task OnLoad()
    {
        var viewModel = await QueryRouter.Send(new GetPant(MemorabiliaId));

        if (viewModel.Brand == null)
            return;

        ViewModel = new SavePantViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SavePant.Command(ViewModel));
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
