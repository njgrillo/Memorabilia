namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class OccupationsProfile : PersonProfile
{
    private OccupationsProfileModel _viewModel;

    protected override void OnParametersSet()
    {
        if (Person == null)
            return;

        _viewModel = new OccupationsProfileModel(Person);
    }
}
