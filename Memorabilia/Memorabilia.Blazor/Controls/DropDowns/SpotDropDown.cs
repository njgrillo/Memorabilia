namespace Memorabilia.Blazor.Controls.DropDowns;

public class SpotDropDown : DropDown<Spot, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = Spot.All;
        Label = "Spot";
    }
}
