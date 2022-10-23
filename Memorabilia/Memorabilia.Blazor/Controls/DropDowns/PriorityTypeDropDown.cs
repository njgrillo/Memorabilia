namespace Memorabilia.Blazor.Controls.DropDowns;

public class PriorityTypeDropDown : DropDown<PriorityType, int>
{
    protected override void OnInitialized()
    {
        Items = PriorityType.All;
        Label = "Priority";
    }
}
