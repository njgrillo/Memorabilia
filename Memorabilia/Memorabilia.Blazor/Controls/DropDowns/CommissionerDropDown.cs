#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class CommissionerDropDown : DropDown<CommissionerViewModel, int>
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int? SportLeagueLevelId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items = (await QueryRouter.Send(new GetCommissioners(SportLeagueLevelId))).Commissioners.ToArray();
        Label = "Commissioner";
    }
}
