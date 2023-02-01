namespace Memorabilia.Blazor.Controls.DropDowns;

public class CerealTypeDropDown : DropDown<CerealType, int>
{
    protected override void OnInitialized()
    {
        Items = CerealType.All;
        Label = "Type";
    }
}
