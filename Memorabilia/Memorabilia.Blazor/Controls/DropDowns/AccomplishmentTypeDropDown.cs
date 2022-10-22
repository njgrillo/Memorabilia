namespace Memorabilia.Blazor.Controls.DropDowns;

public class AccomplishmentTypeDropDown : DropDown<AccomplishmentType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = AccomplishmentType.All;
        Label = "Accomplishment";
    }
}
