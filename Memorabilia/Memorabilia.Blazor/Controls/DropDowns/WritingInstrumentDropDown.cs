namespace Memorabilia.Blazor.Controls.DropDowns;

public class WritingInstrumentDropDown : DropDown<WritingInstrument, int>
{
    protected override string GetMultiSelectionText(List<string> selectedValues)
    => !selectedValues.Any() || selectedValues.Count > 2 
        ? $"{selectedValues.Count} writing instruments selected" 
        : string.Join(", ", selectedValues.Select(item => WritingInstrument.Find(item.ToInt32())?.Name));

    protected override void OnInitialized()
    {
        Items = WritingInstrument.All;
        Label = "Writing Instrument";
    }
}
