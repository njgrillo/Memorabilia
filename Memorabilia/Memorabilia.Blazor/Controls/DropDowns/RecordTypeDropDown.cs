namespace Memorabilia.Blazor.Controls.DropDowns;

public class RecordTypeDropDown : DropDown<RecordType, int>
{
    protected override void OnInitialized()
    {
        Items = RecordType.All;
        Label = "Record Type";
    }
}
