using Memorabilia.Application.Features.Tools.ProfileNew;

namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class OccupationsProfile : PersonProfile
{
    private OccupationsProfileViewModel _viewModel;

    protected override void OnParametersSet()
    {
        if (Person == null)
            return;

        _viewModel = new OccupationsProfileViewModel(Person);
    }
}
