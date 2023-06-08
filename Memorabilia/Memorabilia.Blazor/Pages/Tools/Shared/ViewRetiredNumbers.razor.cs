namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewRetiredNumbers 
    : ViewSportTools<RetiredNumberModel>
{
    private RetiredNumbersModel Model = new();

    private async Task OnInputChange(Franchise franchise)
    {
        Model = await QueryRouter.Send(new GetRetiredNumbers(franchise, Sport));
    }
}
