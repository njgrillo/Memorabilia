namespace Memorabilia.Blazor.Controls.TypeAhead;

public class ThroughTheMailFailureTypeAutoComplete : DomainEntityAutoComplete<ThroughTheMailFailureType>
{
    protected override void OnInitialized()
    {
        Label = "Failure Type";
        Placeholder = "Search by failure type...";
        Items = ThroughTheMailFailureType.All;
        ResetValueOnEmptyText = true;
    }
}
