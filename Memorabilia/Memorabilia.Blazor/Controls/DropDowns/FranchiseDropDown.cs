namespace Memorabilia.Blazor.Controls.DropDowns;

public class FranchiseDropDown : DropDown<Franchise, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = Franchise.All;
        Label = "Franchise";
    }
}
