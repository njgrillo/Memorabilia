namespace Memorabilia.Blazor.Controls.DropDowns;

public class JerseyStyleTypeDropDown : DropDown<JerseyStyleType, int>
{
    protected override void OnInitialized()
    {
        Items = JerseyStyleType.All;
        Label = "Style";
    }
}
