namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeLevelDropDown : ItemTypeEntityDropDown<ItemTypeLevelModel>
{
    protected override async Task OnInitializedAsync()
    {
        Entity.ItemTypeLevel[] itemTypeLevels 
            = await Mediator.Send(new GetItemTypeLevels(ItemType.Id));

        Items = itemTypeLevels.Select(itemTypeLevel => new ItemTypeLevelModel(itemTypeLevel));
        Label = "Level";
    }
}
