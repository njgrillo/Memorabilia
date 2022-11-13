#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class FranchiseDropDown : DropDown<Franchise, int>, INotifyPropertyChanged
{
    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public FranchiseDropDown()
    {
        PropertyChanged += FranchiseDropDown_PropertyChanged;
    }

    public void FranchiseDropDown_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SportLeagueLevel) || e.PropertyName == nameof(SportIds))
        {
            LoadItems();
        }
    }

    protected override string GetMultiSelectionText(List<string> selectedValues)
    {
        return !selectedValues.Any() || selectedValues.Count > 4
            ? $"{selectedValues.Count} franchises selected"
            : string.Join(", ", selectedValues.Select(item => Franchise.Find(item.ToInt32())?.Name));
    }

    protected override void OnInitialized()
    {        
        Label = "Franchise";
        LoadItems();
    }

    private void LoadItems()
    {
        if (SportLeagueLevel != null)
        {
            Items = Franchise.GetAll(SportLeagueLevel);
            return;
        }           

        if (SportIds.Any())
        {
            Items = Franchise.GetAll(SportIds);
            return;
        }            

        Items = Franchise.All;
    }
}
