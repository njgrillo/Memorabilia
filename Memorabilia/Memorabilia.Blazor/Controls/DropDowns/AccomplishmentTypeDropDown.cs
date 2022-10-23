namespace Memorabilia.Blazor.Controls.DropDowns;

public class AccomplishmentTypeDropDown : DropDown<AccomplishmentType, int>
{
    protected override void OnInitialized()
    {
        Items = AccomplishmentType.All;
        Label = "Accomplishment";
    }
}
