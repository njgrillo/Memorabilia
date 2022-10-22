namespace Memorabilia.Blazor.Controls.DropDowns;

public class PhotoTypeDropDown : DropDown<PhotoType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = PhotoType.All;
        Label = "Type";
    }
}
