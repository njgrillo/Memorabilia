namespace Memorabilia.Blazor.Controls.TypeAhead;

public class OccupationAutoComplete : DomainEntityAutoComplete<Occupation>
{
    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Label = "Occupation";
        Placeholder = "Search by occupation...";
        Items = Occupation.All;
    }
}
