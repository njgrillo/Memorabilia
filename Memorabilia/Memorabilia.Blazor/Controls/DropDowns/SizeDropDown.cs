namespace Memorabilia.Blazor.Controls.DropDowns;

public class SizeDropDown : DropDown<Constant.Size, int>
{
    protected override void OnInitialized()
    {
        Items = Constant.Size.All;
        Label = "Size";
    }
}
