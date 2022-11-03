namespace Memorabilia.Blazor.Controls.DropDowns;

public class TeamRoleTypeDropDown : DropDown<TeamRoleType, int>
{
    [Parameter]
    public int SportLeagueLevelId { get; set; }

    protected override void OnInitialized()
    {
        Items = SportLeagueLevelId > 0 ? TeamRoleType.Get(SportLeagueLevel.Find(SportLeagueLevelId)) : TeamRoleType.All;
        Label = "Team Role Type";
    }
}
