namespace Memorabilia.Blazor.Controls.DropDowns;

public class AcquisitionTypeDropDown : DropDown<AcquisitionType, int>
{
    [Parameter]
    public bool IsAutograph { get; set; }

    protected override string GetMultiSelectionText(List<string> selectedValues)
    {
        return !selectedValues.Any() || selectedValues.Count > 3
            ? $"{selectedValues.Count} acquisition types selected"
            : string.Join(", ", selectedValues.Select(item => AcquisitionType.Find(item.ToInt32())?.Name));
    }

    protected override void OnInitialized()
    {
        Items = IsAutograph ? AcquisitionType.All : AcquisitionType.MemorabiliaAcquisitionTypes;
        Label = "Acquisition Type";
    }
}
