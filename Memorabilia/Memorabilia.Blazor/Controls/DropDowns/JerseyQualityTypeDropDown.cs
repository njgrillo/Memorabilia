namespace Memorabilia.Blazor.Controls.DropDowns;

public class JerseyQualityTypeDropDown : DropDown<JerseyQualityType, int>
{
    protected override void OnInitialized()
    {
        Items = JerseyQualityType.All;
        Label = "Quality";
    }
}
