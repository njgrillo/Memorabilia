namespace Memorabilia.Blazor.Controls.DropDowns;

public class OrientationDropDown : DropDown<Constant.Orientation, int>
{
    protected override void OnInitialized()
    {
        Items = Constant.Orientation.All;
        Label = "Orientation";
    }
}
