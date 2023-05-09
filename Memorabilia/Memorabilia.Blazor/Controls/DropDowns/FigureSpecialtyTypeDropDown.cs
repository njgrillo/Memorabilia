

namespace Memorabilia.Blazor.Controls.DropDowns;

public class FigureSpecialtyTypeDropDown : DropDown<FigureSpecialtyType, int>, INotifyPropertyChanged
{
    [Parameter]
    public FigureType FigureType { get; set; }

#pragma warning disable CS0067
    public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

    public FigureSpecialtyTypeDropDown()
    {
        PropertyChanged += FigureSpecialtyTypeDropDown_PropertyChanged;
    }

    protected override void OnInitialized()
    {
        Label = "Speciality Type";

        LoadItems();        
    }

    private void FigureSpecialtyTypeDropDown_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(FigureType))
        {
            LoadItems();
        }
    }

    private void LoadItems()
    {
        Items = FigureType != null ? FigureSpecialtyType.GetAll(FigureType) : FigureSpecialtyType.All;
    }
}
