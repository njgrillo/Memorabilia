namespace Memorabilia.Blazor.Controls.DropDowns;

public class BammerTypeDropDown : DropDown<BammerType, int>
{
    protected override void OnInitialized()
    {
        Items = BammerType.All;
        Label = "Type";
    }
}
