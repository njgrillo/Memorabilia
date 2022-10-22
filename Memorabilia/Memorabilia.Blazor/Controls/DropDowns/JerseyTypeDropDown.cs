namespace Memorabilia.Blazor.Controls.DropDowns;

public class JerseyTypeDropDown : DropDown<JerseyType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = JerseyType.All;
        Label = "Type";
    }
}
