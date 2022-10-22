namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeLevelDropDown : ItemTypeEntityDropDown<ItemTypeLevelViewModel>
{
    protected override async Task OnInitializedAsync()
    {
        Items = (await QueryRouter.Send(new GetItemTypeLevels(ItemType.Id))).ItemTypeLevels;
        Label = "Level";
    }
}
