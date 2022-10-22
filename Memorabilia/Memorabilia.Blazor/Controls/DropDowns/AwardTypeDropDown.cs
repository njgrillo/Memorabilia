namespace Memorabilia.Blazor.Controls.DropDowns;

public class AwardTypeDropDown : DropDown<AwardType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = AwardType.All;
        Label = "Award";
    }
}
