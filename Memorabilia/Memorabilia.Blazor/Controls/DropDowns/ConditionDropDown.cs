namespace Memorabilia.Blazor.Controls.DropDowns;

public class ConditionDropDown : DropDown<Condition, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = Condition.All;
        Label = "Condition";
    }
}
