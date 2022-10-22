namespace Memorabilia.Blazor.Controls.DropDowns;

public class HelmetFinishDropDown : DropDown<HelmetFinish, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = HelmetFinish.All;
        Label = "Finish";
    }
}
