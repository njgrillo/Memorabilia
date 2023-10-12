namespace Memorabilia.Blazor.Controls.DropDowns;

public class PrivateSigningPersonDropDown : DropDown<PersonModel, int>
{
    [Parameter]
    public PersonModel[] AvailablePeople { get; set; }
        = Array.Empty<PersonModel>();

    protected override void OnInitialized()
    {
        Label = "People";
    }

    protected override void OnParametersSet()
    {
        Items = AvailablePeople;
    }

    protected override string GetItemDisplayText(PersonModel item)
        => $"{item.ProfileName}";
}
