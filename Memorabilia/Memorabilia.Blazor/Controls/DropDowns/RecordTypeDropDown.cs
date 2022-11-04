namespace Memorabilia.Blazor.Controls.DropDowns;

public class RecordTypeDropDown : DropDown<RecordType, int>
{
    [Parameter]
    public int SportId { get; set; }

    protected override void OnInitialized()
    {
        Items = SportId > 0 ? RecordType.GetAll(SportId) : RecordType.All;
        Label = "Record Type";
    }
}
