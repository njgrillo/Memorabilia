namespace Memorabilia.Blazor.Controls.Fields;

public partial class TextField : Field 
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string HelperText { get; set; }

    [Parameter]
    public InputType InputType { get; set; } 
        = InputType.Text;

    [Parameter]
    public int Lines { get; set; } 
        = 1;

    [Parameter]
    public int MaxLength { get; set; } 
        = int.MaxValue;

    [Parameter]
    public EventCallback<FocusEventArgs> OnBlur { get; set; }

    [Parameter]
    public string PlaceHolder { get; set; }

    [Parameter]
    public string SelectedText { get; set; }

    [Parameter]
    public EventCallback<string> SelectedTextChanged { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
