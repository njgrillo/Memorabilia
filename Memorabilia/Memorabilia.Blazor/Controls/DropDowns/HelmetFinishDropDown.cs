namespace Memorabilia.Blazor.Controls.DropDowns;

public class HelmetFinishDropDown : DropDown<HelmetFinish, int>
{
    protected override void OnInitialized()
    {
        Items = HelmetFinish.All;
        Label = "Finish";
    }
}
