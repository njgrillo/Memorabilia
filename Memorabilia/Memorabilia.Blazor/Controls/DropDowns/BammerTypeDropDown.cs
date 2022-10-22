namespace Memorabilia.Blazor.Controls.DropDowns;

public class BammerTypeDropDown : DropDown<BammerType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = BammerType.All;
        Label = "Type";
    }
}
