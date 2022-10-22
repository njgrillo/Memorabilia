namespace Memorabilia.Blazor.Controls.DropDowns;

public class OccupationTypeDropDown : DropDown<OccupationType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = OccupationType.All;
        Label = "Occupation Type";
    }
}
