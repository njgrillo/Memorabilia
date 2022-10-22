namespace Memorabilia.Blazor.Controls.DropDowns;

public class HelmetTypeDropDown : DropDown<HelmetType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = HelmetType.All;
        Label = "Type";
    }
}
