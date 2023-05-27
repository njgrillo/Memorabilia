namespace Memorabilia.Blazor.Controls.TypeAhead;

public class ProjectTypeAutoComplete : DomainEntityAutoComplete<ProjectType>
{
    protected override void OnInitialized()
    {
        Label = "Project Type";
        Placeholder = "Search by project...";
        ResetValueOnEmptyText = true;

        Items = ProjectType.All;
    }
}
