namespace Memorabilia.Blazor.Controls.TypeAhead;

public class CollegeAutoComplete : DomainEntityAutoComplete<College>
{
    protected override void OnInitialized()
    {
        Label = "College";
        Placeholder = "Search by college...";
        ResetValueOnEmptyText = true;
        Items = College.All;
    }
}
