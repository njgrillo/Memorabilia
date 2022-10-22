namespace Memorabilia.Blazor.Controls.DropDowns;

public class InternationalHallOfFameTypeDropDown : DropDown<InternationalHallOfFameType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = InternationalHallOfFameType.All;
        Label = "International Hall of Fame Type";
    }
}
