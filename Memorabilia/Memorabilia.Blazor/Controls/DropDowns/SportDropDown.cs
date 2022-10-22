namespace Memorabilia.Blazor.Controls.DropDowns;

public class SportDropDown : DropDown<Domain.Constants.Sport, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = Domain.Constants.Sport.All;
        Label = "Sport";
    }
}
