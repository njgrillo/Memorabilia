namespace Memorabilia.Blazor.Controls.TypeAhead;

public class ProjectTypeAutoComplete : DomainEntityAutoComplete<ProjectType>
{
    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Label = "Project Type";
        Placeholder = "Search by project...";
        ResetValueOnEmptyText = true;

        Items = ProjectType.All;
    }
}
