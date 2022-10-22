namespace Memorabilia.Blazor.Controls.DropDowns;

public class CollegeDropDown : DropDown<College, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = College.All;
        Label = "College";
    }
}
