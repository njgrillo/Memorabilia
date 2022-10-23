namespace Memorabilia.Blazor.Controls.DropDowns;

public class AwardTypeDropDown : DropDown<AwardType, int>
{
    protected override void OnInitialized()
    {
        Items = AwardType.All;
        Label = "Award";
    }
}
