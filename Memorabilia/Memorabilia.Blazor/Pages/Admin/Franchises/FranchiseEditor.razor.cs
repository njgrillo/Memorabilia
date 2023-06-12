namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class FranchiseEditor : EditItem<FranchiseEditModel, FranchiseModel>
{
    private bool DisplaySportLeagueLevel => Id == 0;

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveFranchise(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new FranchiseEditModel(new FranchiseModel(await QueryRouter.Send(new GetFranchise(Id))));
    }
}
