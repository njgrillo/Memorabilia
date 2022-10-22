namespace Memorabilia.Blazor.Controls.DropDowns;

public class OccupationDropDown : DropDown<Occupation, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = Occupation.All;
        Label = "Occupation";
    }
}
