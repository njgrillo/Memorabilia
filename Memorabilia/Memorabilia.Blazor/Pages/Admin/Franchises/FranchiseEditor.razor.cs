namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class FranchiseEditor 
    : EditItem<FranchiseEditModel, FranchiseModel>
{
    private bool DisplaySportLeagueLevel
        => Id == 0;    

    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await Mediator.Send(new GetFranchise(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveFranchise(EditModel));
    }
}
