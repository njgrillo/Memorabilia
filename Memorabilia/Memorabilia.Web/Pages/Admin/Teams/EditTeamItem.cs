namespace Memorabilia.Web.Pages.Admin.Teams;

public class EditTeamItem : WebPage
{
    [Parameter]
    public int SportLeagueLevelId { get; set; }

    [Parameter]
    public int TeamId { get; set; }
}
