namespace Memorabilia.Blazor.Controls.DropDowns;

public class PriorityTypeDropDown : DropDown<PriorityType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = PriorityType.All;
        Label = "Priority";
    }
}
