#nullable disable

namespace Memorabilia.Blazor.Controls.DatePickers;

public partial class DatePicker
{
    [Parameter]
    public string DateFormat { get; set; } = "MM/dd/yyyy";

    [Parameter]
    public bool Editable { get; set; } = true;

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public DateMask Mask { get; set; } = new DateMask("MM/dd/yyyy");

    [Parameter]
    public DateTime? SelectedDate { get; set; }

    [Parameter]
    public EventCallback<DateTime?> SelectedDateChanged { get; set; }

    [Parameter]
    public Variant Variant { get; set; } = Variant.Outlined;
}
