namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewCollegesTool : ViewSportTools<PersonCollegeViewModel>
{
    private PersonCollegesViewModel _viewModel = new();

    private async Task OnInputChange(College college)
    {
        _viewModel = await QueryRouter.Send(new GetPersonColleges(college, Sport));
    }
}
