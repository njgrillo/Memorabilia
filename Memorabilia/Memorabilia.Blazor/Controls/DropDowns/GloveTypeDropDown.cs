namespace Memorabilia.Blazor.Controls.DropDowns;

public class GloveTypeDropDown : DropDown<GloveType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = GloveType.All;
        Label = "Glove Type";
    }
}
