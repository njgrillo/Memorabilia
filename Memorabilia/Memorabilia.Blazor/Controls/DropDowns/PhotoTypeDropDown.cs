namespace Memorabilia.Blazor.Controls.DropDowns;

public class PhotoTypeDropDown : DropDown<PhotoType, int>
{
    protected override void OnInitialized()
    {
        Items = PhotoType.All;
        Label = "Type";
    }
}
