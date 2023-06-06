namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewCollegesTool : ViewSportTools<PersonCollegeModel>
{
    private PersonCollegesModel _viewModel = new();

    private async Task OnInputChange(College college)
    {
        _viewModel = await QueryRouter.Send(new GetPersonColleges(college, Sport));
    }
}
