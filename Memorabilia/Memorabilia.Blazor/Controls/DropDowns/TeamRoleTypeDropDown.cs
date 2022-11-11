namespace Memorabilia.Blazor.Controls.DropDowns;

public class TeamRoleTypeDropDown : DropDown<TeamRoleType, int>, INotifyPropertyChanged
{
    [Parameter]
    public int SportLeagueLevelId { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public TeamRoleTypeDropDown()
    {
        PropertyChanged += TeamRoleTypeDropDown_PropertyChanged;
    }

    public void TeamRoleTypeDropDown_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SportLeagueLevelId))
        {
            LoadItems();
        }
    }

    protected override void OnInitialized()
    {
        Label = "Team Role Type";
        LoadItems();        
    }

    private void LoadItems()
    {
        Items = SportLeagueLevelId > 0 ? TeamRoleType.Get(SportLeagueLevel.Find(SportLeagueLevelId)) : TeamRoleType.All;
    }
}
