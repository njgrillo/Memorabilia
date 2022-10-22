namespace Memorabilia.Blazor.Controls.DropDowns;

public class BatTypeDropDown : DropDown<BatType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = BatType.All;
        Label = "Bat Type";
    }
}
