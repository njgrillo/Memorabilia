namespace Memorabilia.Blazor.Controls.DropDowns;

public class TeamRoleTypeDropDown : DropDown<TeamRoleType, int>
{
    protected override void OnInitialized()
    {
        Items = TeamRoleType.All;
        Label = "Team Role Type";
    }
}
