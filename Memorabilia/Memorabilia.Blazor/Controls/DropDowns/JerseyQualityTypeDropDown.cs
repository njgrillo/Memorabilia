namespace Memorabilia.Blazor.Controls.DropDowns;

public class JerseyQualityTypeDropDown : DropDown<JerseyQualityType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = JerseyQualityType.All;
        Label = "Quality";
    }
}
