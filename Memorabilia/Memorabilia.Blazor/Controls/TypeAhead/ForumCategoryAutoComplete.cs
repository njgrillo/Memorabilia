namespace Memorabilia.Blazor.Controls.TypeAhead;

public class ForumCategoryAutoComplete : DomainEntityAutoComplete<ForumCategory>
{
    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Items = ForumCategory.All;
        Label = "Category";
        Placeholder = "Search by Category...";
    }
}
