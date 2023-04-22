using Memorabilia.Application.Features.Tools.ProfileNew;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class OccupationsProfile
{
    [Parameter]
    public Person Person { get; set; }

    private OccupationsProfileViewModel _viewModel;

    protected override void OnParametersSet()
    {
        if (Person == null)
            return;

        _viewModel = new OccupationsProfileViewModel(Person);
    }
}
