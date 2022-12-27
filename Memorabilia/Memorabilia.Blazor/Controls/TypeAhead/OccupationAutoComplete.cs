namespace Memorabilia.Blazor.Controls.TypeAhead;

public class OccupationAutoComplete : DomainEntityAutoComplete<Occupation>
{
    protected override void OnInitialized()
    {
        Label = "Occupation";
        Placeholder = "Search by occupation...";
        Items = Occupation.All;
    }
}
