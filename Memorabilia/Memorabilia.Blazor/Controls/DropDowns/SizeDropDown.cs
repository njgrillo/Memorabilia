namespace Memorabilia.Blazor.Controls.DropDowns;

public class SizeDropDown : DropDown<Domain.Constants.Size, int>
{
    protected override void OnInitialized()
    {
        Items = Domain.Constants.Size.All;
        Label = "Size";
    }
}
