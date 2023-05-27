namespace Memorabilia.Blazor.Controls.Fields;

public partial class NumericField<TType> : Field
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool HideSpinButtons { get; set; } = true;

    [Parameter]
    public TType Maximum { get; set; }

    [Parameter]
    public TType Value { get; set; }

    [Parameter]
    public EventCallback<TType> ValueChanged { get; set; }
}
