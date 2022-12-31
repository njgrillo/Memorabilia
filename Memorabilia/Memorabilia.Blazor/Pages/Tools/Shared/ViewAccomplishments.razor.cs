namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAccomplishments : ViewSportTools<AccomplishmentViewModel>
{
    private AccomplishmentsViewModel _viewModel = new();        

    private async Task OnInputChange(AccomplishmentType accomplishmentType)
    {
        _viewModel = await QueryRouter.Send(new GetAccomplishments(accomplishmentType, Sport));
    }
}
