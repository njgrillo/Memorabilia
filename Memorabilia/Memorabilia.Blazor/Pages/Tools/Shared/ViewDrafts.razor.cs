namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewDrafts 
    : ViewSportTools<DraftModel>
{
    protected DraftsModel Model = new();

    private async Task OnInputChange(Franchise franchise)
    {
        Model = new(await QueryRouter.Send(new GetDrafts(franchise, Sport)), Sport)
                {
                    Franchise = franchise
                }; 
    }
}
