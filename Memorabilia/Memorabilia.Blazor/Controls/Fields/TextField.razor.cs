#nullable disable

using Microsoft.AspNetCore.Components.Web;

namespace Memorabilia.Blazor.Controls.Fields;

public partial class TextField : Field 
{
    [Parameter]
    public Adornment Adornment { get; set; }

    [Parameter]
    public string AdornmentIcon { get; set; }

    [Parameter]
    public string Class { get; set; }

    [Parameter]
    public string HelperText { get; set; }

    [Parameter]
    public MudBlazor.Size IconSize { get; set; }

    [Parameter]
    public InputType InputType { get; set; }

    [Parameter]
    public int Lines { get; set; } = 1;

    [Parameter]
    public int MaxLength { get; set; }

    [Parameter]
    public EventCallback<FocusEventArgs> OnBlur { get; set; }

    [Parameter]
    public string PlaceHolder { get; set; }

    [Parameter]
    public string SelectedText { get; set; }

    [Parameter]
    public EventCallback<string> SelectedTextChanged { get; set; }
}
