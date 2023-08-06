namespace Memorabilia.Blazor.Controls.Fields;

public abstract class Field : ComponentBase
{
    [Parameter]
    public bool DisplaySkeleton { get; set; }

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public Variant Variant { get; set; }
        = Variant.Outlined;
}
