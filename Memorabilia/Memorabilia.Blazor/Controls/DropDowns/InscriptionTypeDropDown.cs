namespace Memorabilia.Blazor.Controls.DropDowns;

public class InscriptionTypeDropDown : DropDown<InscriptionType, int>
{
    protected override void OnInitialized()
    {
        Items = InscriptionType.All;
        Label = "Type";
    }
}
