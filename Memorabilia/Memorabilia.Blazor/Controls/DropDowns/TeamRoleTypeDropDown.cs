

namespace Memorabilia.Blazor.Controls.DropDowns;

public class TeamRoleTypeDropDown : DropDown<TeamRoleType, int>, INotifyPropertyChanged
{
    [Parameter]
    public int SportLeagueLevelId { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

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
