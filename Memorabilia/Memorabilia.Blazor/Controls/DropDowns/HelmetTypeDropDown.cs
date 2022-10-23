namespace Memorabilia.Blazor.Controls.DropDowns;

public class HelmetTypeDropDown : DropDown<HelmetType, int>
{
    protected override void OnInitialized()
    {
        Items = HelmetType.All;
        Label = "Type";
    }
}
