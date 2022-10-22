namespace Memorabilia.Blazor.Controls.DropDowns;

public class InscriptionTypeDropDown : DropDown<InscriptionType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = InscriptionType.All;
        Label = "Type";
    }
}
