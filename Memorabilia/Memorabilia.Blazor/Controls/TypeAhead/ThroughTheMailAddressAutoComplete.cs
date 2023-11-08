namespace Memorabilia.Blazor.Controls.TypeAhead;

public class ThroughTheMailAddressAutoComplete
    : Autocomplete<AddressEditModel>
{
    [Parameter]
    public int PersonId { get; set; }

    private int _personId;

    protected IEnumerable<AddressEditModel> Items { get; set; }
        = Enumerable.Empty<AddressEditModel>();

    public override string GetDisplayText(AddressEditModel item)
        => item?.Name;

    protected override string GetItemSelectedText(AddressEditModel item)
        => item?.Name;

    protected override string GetItemText(AddressEditModel item)
        => item?.Name;

    protected override async Task OnParametersSetAsync()
    {
        Label = "Existing Address";
        Placeholder = "Search by address...";

        await LoadItems();
    }

    public override async Task<IEnumerable<AddressEditModel>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<AddressEditModel>();

        return await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)));
    }

    private async Task LoadItems()
    {
        if (PersonId == 0 || _personId == PersonId)
            return;

        Entity.Address[] addresses = await Mediator.Send(new GetThroughTheMailAddresses(PersonId));

        Items = addresses.Select(address => new AddressEditModel(address));

        _personId = PersonId;
    }
}
