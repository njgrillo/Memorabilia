namespace Memorabilia.Blazor.Controls.DropDowns;

public class ProjectStatusTypeDropDown : DropDown<ProjectStatusType, int>
{
    protected override void OnInitialized()
    {
        Items = ProjectStatusType.All;
        Label = "Status";
    }
}
