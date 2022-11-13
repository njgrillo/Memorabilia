namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAccomplishments : ViewSportTools<AccomplishmentViewModel>
{
    private AccomplishmentsViewModel _viewModel = new();        

    private async Task OnInputChange(int accomplishmentTypeId)
    {
        _viewModel = await QueryRouter.Send(new GetAccomplishments(accomplishmentTypeId, SportLeagueLevel));
    }
}
