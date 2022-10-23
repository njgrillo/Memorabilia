namespace Memorabilia.Blazor.Controls.DropDowns;

public class HelmetQualityTypeDropDown : DropDown<HelmetQualityType, int>
{
    protected override void OnInitialized()
    {
        Items = HelmetQualityType.All;
        Label = "Quality";
    }
}
