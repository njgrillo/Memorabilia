namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeSpotDropDown : ItemTypeEntityDropDown<ItemTypeSpotViewModel>
{
    protected override async Task OnInitializedAsync()
    {
        Items = (await QueryRouter.Send(new GetItemTypeSpots(ItemType.Id))).ItemTypeSpots;
        Label = "Spot";
    }
}
