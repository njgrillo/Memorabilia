namespace Memorabilia.Blazor.Controls.DropDowns;

public class RecordTypeDropDown : DropDown<RecordType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = RecordType.All;
        Label = "Record Type";
    }
}
