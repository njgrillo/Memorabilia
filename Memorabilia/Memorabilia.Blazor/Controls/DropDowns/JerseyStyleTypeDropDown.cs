namespace Memorabilia.Blazor.Controls.DropDowns;

public class JerseyStyleTypeDropDown : DropDown<JerseyStyleType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = JerseyStyleType.All;
        Label = "Style";
    }
}
