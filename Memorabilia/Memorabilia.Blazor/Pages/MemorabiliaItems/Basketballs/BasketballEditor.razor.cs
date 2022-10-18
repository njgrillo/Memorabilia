#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Basketballs;

public partial class BasketballEditor : MemorabiliaItem<SaveBasketballViewModel>
{
    public CommissionerViewModel[] Commissioners;   

    protected async Task OnLoad()
    {      
        await LoadCommissioners();

        var viewModel = await QueryRouter.Send(new GetBasketball.Query(MemorabiliaId));

        if (viewModel.Brand == null)
        {
            SetDefaults();
            return;
        }    

        ViewModel = new SaveBasketballViewModel(viewModel);
    }    

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveBasketball.Command(ViewModel));
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
