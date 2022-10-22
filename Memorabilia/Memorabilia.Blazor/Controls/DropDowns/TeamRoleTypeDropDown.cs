namespace Memorabilia.Blazor.Controls.DropDowns;

public class TeamRoleTypeDropDown : DropDown<TeamRoleType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = TeamRoleType.All;
        Label = "Team Role Type";
    }
}
