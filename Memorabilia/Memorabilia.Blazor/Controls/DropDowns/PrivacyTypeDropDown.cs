namespace Memorabilia.Blazor.Controls.DropDowns;

public class PrivacyTypeDropDown : DropDown<PrivacyType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = PrivacyType.All;
        Label = "Privacy Type";
    }
}
