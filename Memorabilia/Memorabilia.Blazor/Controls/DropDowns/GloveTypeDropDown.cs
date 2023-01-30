namespace Memorabilia.Blazor.Controls.DropDowns;

public class GloveTypeDropDown : DropDown<GloveType, int>
{
    [Parameter]
    public Sport Sport { get; set; }

    protected override void OnInitialized()
    {
        SetGloveTypes();
        Label = "Glove Type";
    }

    protected override void OnParametersSet()
    {
        SetGloveTypes();
    }

    private void SetGloveTypes()
    {
        Items = Sport != null
            ? GloveType.GetAll(Sport)
            : GloveType.All;
    }
}
