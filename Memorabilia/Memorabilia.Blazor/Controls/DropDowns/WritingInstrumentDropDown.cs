namespace Memorabilia.Blazor.Controls.DropDowns;

public class WritingInstrumentDropDown : DropDown<WritingInstrument, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = WritingInstrument.All;
        Label = "Writing Instrument";
    }
}
