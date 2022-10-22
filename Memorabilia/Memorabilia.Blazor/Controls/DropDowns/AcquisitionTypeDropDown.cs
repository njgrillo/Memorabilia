namespace Memorabilia.Blazor.Controls.DropDowns;

public class AcquisitionTypeDropDown : DropDown<AcquisitionType, int>
{
    [Parameter]
    public bool IsAutograph { get; set; }   

    protected override async Task OnInitializedAsync()
    {
        Items = IsAutograph ? AcquisitionType.All : AcquisitionType.MemorabiliaAcquisitionTypes;
        Label = "Acquisition Type";
    }
}
