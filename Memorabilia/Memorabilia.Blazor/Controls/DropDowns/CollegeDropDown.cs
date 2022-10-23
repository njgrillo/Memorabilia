namespace Memorabilia.Blazor.Controls.DropDowns;

public class CollegeDropDown : DropDown<College, int>
{
    protected override void OnInitialized()
    {
        Items = College.All;
        Label = "College";
    }
}
