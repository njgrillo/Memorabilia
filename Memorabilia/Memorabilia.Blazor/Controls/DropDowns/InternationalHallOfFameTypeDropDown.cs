namespace Memorabilia.Blazor.Controls.DropDowns;

public class InternationalHallOfFameTypeDropDown : DropDown<InternationalHallOfFameType, int>
{
    protected override void OnInitialized()
    {
        Items = InternationalHallOfFameType.All;
        Label = "International Hall of Fame Type";
    }
}
