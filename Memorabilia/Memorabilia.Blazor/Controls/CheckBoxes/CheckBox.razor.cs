namespace Memorabilia.Blazor.Controls.CheckBoxes;

public partial class CheckBox<TType>
{
    [Parameter]
    public TType Checked { get; set; }

    [Parameter]
    public EventCallback<TType> CheckedChanged { get; set; }

    [Parameter]
    public string Label { get; set; }
}
