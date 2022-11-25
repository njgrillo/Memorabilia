namespace Memorabilia.Blazor.Controls.TypeAhead;

public class ItemTypeAutoComplete : DomainEntityAutoComplete<ItemType>
{
    protected override void OnInitialized()
    {
        Label = "Item Type";
        Placeholder = "Search by item type...";
        Items = ItemType.All;
    }
}
