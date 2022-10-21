#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Footballs;

public partial class FootballEditor : MemorabiliaItem<SaveFootballViewModel>
{
    public CommissionerViewModel[] Commissioners;

    protected async Task OnLoad()
    {
        await LoadCommissioners();

        var viewModel = await QueryRouter.Send(new GetFootball(MemorabiliaId));

        if (viewModel.Brand == null)
        {
            SetDefaults();
            return;
        }

        ViewModel = new SaveFootballViewModel(viewModel);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveFootball.Command(ViewModel));
    }

    private async Task LoadCommissioners()
    {
        Commissioners = (await QueryRouter.Send(new GetCommissioners(ViewModel.SportLeagueLevel.Id))).Commissioners.ToArray();
    }

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }

    private void SelectedTeamChanged(SaveTeamViewModel team)
    {
        ViewModel.Team = team;
    }

    private void SetDefaults()
    {
        ViewModel.GameStyleTypeId = GameStyleType.None.Id;
    }
}
