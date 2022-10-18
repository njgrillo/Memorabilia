#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Baseballs;

public partial class BaseballEditor : MemorabiliaItem<SaveBaseballViewModel>
{
    public CommissionerViewModel[] Commissioners;

    protected async Task OnLoad()
    {
        await LoadCommissioners();

        var viewModel = await QueryRouter.Send(new GetBaseball.Query(MemorabiliaId));

        if (viewModel.Brand == null)
        {
            SetDefaults();
            return;
        }

        ViewModel = new SaveBaseballViewModel(viewModel);
    }

    protected async Task OnSave()
    {    
        await CommandRouter.Send(new SaveBaseball.Command(ViewModel));
    }

    private async Task LoadCommissioners()
    {
        Commissioners = (await QueryRouter.Send(new GetCommissioners(ViewModel.SportLeagueLevel.Id))).Commissioners.ToArray();
    }        

    private void SelectedPersonChanged(SavePersonViewModel person)
    {
        ViewModel.Person = person;
    }

    private void SetDefaults()
    {
        ViewModel.GameStyleTypeId = GameStyleType.None.Id;
    }
}
