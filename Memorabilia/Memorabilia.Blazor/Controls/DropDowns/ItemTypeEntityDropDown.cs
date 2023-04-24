

namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeEntityDropDown<T> : DropDown<T, int> where T : class, IWithName, IWithValue<int>
{
    [Parameter]
    public ItemType ItemType { get; set; }
}
