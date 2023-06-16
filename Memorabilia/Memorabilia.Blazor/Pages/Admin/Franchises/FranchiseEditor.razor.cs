namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class FranchiseEditor 
    : EditItem<FranchiseEditModel, FranchiseModel>
{
    private bool DisplaySportLeagueLevel
        => Id == 0;

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveFranchise(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetFranchise(Id))).ToEditModel();
    }
}
