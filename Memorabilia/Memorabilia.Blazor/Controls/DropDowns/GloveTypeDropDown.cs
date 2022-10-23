namespace Memorabilia.Blazor.Controls.DropDowns;

public class GloveTypeDropDown : DropDown<GloveType, int>
{
    protected override void OnInitialized()
    {
        Items = GloveType.All;
        Label = "Glove Type";
    }
}
