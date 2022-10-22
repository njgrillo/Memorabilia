namespace Memorabilia.Blazor.Controls.DropDowns;

public class OrientationDropDown : DropDown<Domain.Constants.Orientation, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = Domain.Constants.Orientation.All;
        Label = "Orientation";
    }
}
