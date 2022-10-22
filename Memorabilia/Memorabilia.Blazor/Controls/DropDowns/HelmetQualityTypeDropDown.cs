namespace Memorabilia.Blazor.Controls.DropDowns;

public class HelmetQualityTypeDropDown : DropDown<HelmetQualityType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = HelmetQualityType.All;
        Label = "Quality";
    }
}
