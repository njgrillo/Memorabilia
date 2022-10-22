namespace Memorabilia.Blazor.Controls.DropDowns;

public class SizeDropDown : DropDown<Domain.Constants.Size, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = Domain.Constants.Size.All;
        Label = "Size";
    }
}
