namespace Memorabilia.Blazor.Controls.DropDowns;

public class LeaguePresidentDropDown 
    : DropDown<LeaguePresidentModel, int>, INotifyPropertyChanged
{
    [Parameter]
    public League League { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

    public LeaguePresidentDropDown()
    {
        PropertyChanged += LeaguePresidentDropDown_PropertyChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        Label = "League President";

        await LoadItems();
    }

    protected override string GetItemDisplayText(LeaguePresidentModel item)
        => $"{item.Person.DisplayName} ({item.BeginYear} - {(item.EndYear.HasValue ? item.EndYear : "current")})";

    private async void LeaguePresidentDropDown_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(League) || e.PropertyName == nameof(SportLeagueLevel))
        {
            await LoadItems();
        }
    }

    private async Task LoadItems()
    {
        Entity.LeaguePresident[] presidents 
            = await QueryRouter.Send(new GetLeaguePresidents(SportLeagueLevel?.Id, League?.Id));

        Items = presidents.Select(president => new LeaguePresidentModel(president));
    }
}
