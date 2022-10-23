namespace Memorabilia.Blazor.Controls.DropDowns;

public class JerseyTypeDropDown : DropDown<JerseyType, int>
{
    protected override void OnInitialized()
    {
        Items = JerseyType.All;
        Label = "Type";
    }
}
