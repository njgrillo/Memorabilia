namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeSpotDropDown : ItemTypeEntityDropDown<ItemTypeSpotModel>
{
    protected override async Task OnInitializedAsync()
    {
        Entity.ItemTypeSpot[] itemTypeSpots 
            = await Mediator.Send(new GetItemTypeSpots(ItemType.Id));

        Items = itemTypeSpots.Select(itemTypeSpot => new ItemTypeSpotModel(itemTypeSpot));
        Label = "Spot";
    }
}
