namespace Memorabilia.Blazor.Controls.DropDowns;

public class OccupationTypeDropDown : DropDown<OccupationType, int>
{
    protected override void OnInitialized()
    {
        Items = OccupationType.All;
        Label = "Occupation Type";
    }
}
