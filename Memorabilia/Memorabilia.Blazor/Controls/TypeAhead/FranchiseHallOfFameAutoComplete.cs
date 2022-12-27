namespace Memorabilia.Blazor.Controls.TypeAhead;

public class FranchiseHallOfFameAutoComplete : DomainEntityAutoComplete<FranchiseHallOfFameType>
{
    protected override void OnInitialized()
    {
        Label = "Franchise Hall of Fame";
        Placeholder = "Search by franchise...";
        Items = FranchiseHallOfFameType.All;
    }
}
