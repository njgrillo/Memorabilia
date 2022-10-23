namespace Memorabilia.Blazor.Controls.DropDowns;

public class OccupationDropDown : DropDown<Occupation, int>
{
    protected override void OnInitialized()
    {
        Items = Occupation.All;
        Label = "Occupation";
    }
}
