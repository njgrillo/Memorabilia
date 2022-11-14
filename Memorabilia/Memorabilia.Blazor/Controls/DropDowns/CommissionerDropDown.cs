#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class CommissionerDropDown : DropDown<CommissionerViewModel, int>
{
    [Parameter]
    public int? SportLeagueLevelId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items = (await QueryRouter.Send(new GetCommissioners(SportLeagueLevelId))).Commissioners.ToArray();
        Label = "Commissioner";
    }

    protected override string GetItemDisplayText(CommissionerViewModel item)
    {
        return $"{item.Person.DisplayName} ({item.BeginYear} - {(item.EndYear.HasValue ? item.EndYear : "current")})";
    }
}
