namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PrivateSigningItemGroupAutoComplete : DomainEntityAutoComplete<PrivateSigningItemGroup>
{
    protected override void OnInitialized()
    {
        Label = "Category";
        Placeholder = "Search by category...";
        Items = PrivateSigningItemGroup.All;
    }
}
