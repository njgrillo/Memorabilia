namespace Memorabilia.Blazor.Controls.DropDowns;

public abstract class GameStyleDropDown<T> 
    : DropDown<T, int>, INotifyPropertyChanged where T : DomainItemConstant
{
    [Parameter]
    public GameStyleType GameStyleType { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

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

    private void GameStyleDropDown_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(GameStyleType))
            LoadItems();
    }
}
