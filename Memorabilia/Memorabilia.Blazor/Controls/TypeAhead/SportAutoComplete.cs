namespace Memorabilia.Blazor.Controls.TypeAhead;

public class SportAutoComplete : DomainEntityAutoComplete<Sport>
{
    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Label = "Sport";
        Placeholder = "Search by sport...";
        Items = Sport.All;
    }
}
