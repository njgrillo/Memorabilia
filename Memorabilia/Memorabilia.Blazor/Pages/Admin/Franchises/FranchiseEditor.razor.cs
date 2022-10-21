namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class FranchiseEditor : EditItem<SaveFranchiseViewModel, FranchiseViewModel>
{
    private bool DisplaySportLeagueLevel;

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveFranchise(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
        {
            DisplaySportLeagueLevel = true;
            return;
        }

        ViewModel = new SaveFranchiseViewModel(await Get(new GetFranchise(Id)));
    }
}
