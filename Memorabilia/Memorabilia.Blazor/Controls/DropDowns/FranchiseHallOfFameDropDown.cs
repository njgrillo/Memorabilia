namespace Memorabilia.Blazor.Controls.DropDowns;

public class FranchiseHallOfFameDropDown : DropDown<FranchiseHallOfFameType, int>
{
    protected override string GetItemDisplayText(FranchiseHallOfFameType item)
    {
        return item.ToString();
    }

    protected override int GetItemDisplayValue(FranchiseHallOfFameType item)
    {
        return item.Franchise.Id;
    }

    protected override void OnInitialized()
    {
        Items = FranchiseHallOfFameType.All;
        Label = "Franchise HOF";
    }
}
