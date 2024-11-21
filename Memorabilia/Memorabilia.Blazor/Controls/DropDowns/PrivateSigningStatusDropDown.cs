namespace Memorabilia.Blazor.Controls.DropDowns;

public class PrivateSigningStatusDropDown : DropDown<PrivateSigningStatus, int>
{
    protected override void OnInitialized()
    {
        Items = PrivateSigningStatus.All;
        Label = "Status";
    }
}
