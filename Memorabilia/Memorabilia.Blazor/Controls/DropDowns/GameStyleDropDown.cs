#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public abstract class GameStyleDropDown<T> : DropDown<T, int>, INotifyPropertyChanged where T : DomainItemConstant
{
    [Parameter]
    public GameStyleType GameStyleType { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public GameStyleDropDown()
    {
        PropertyChanged += GameStyleDropDown_PropertyChanged;
    }

    protected abstract void LoadItems();

    protected override void OnInitialized()
    {
        Label = "Type";

        LoadItems();
    }

    private async void GameStyleDropDown_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(GameStyleType))
            LoadItems();
    }
}
