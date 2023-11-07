namespace Memorabilia.Blazor.Controls.TypeAhead;

public class ThroughTheMailAddressAutoComplete
    : Autocomplete<Models.Addresses.Address>
{
    [Parameter]
    public int PersonId { get; set; }

    private int _personId;

    protected IEnumerable<Models.Addresses.Address> Items { get; set; }
        = Enumerable.Empty<Models.Addresses.Address>();

    public override string GetDisplayText(Models.Addresses.Address item)
        => item?.Name;

    protected override string GetItemSelectedText(Models.Addresses.Address item)
        => item?.Name;

    protected override string GetItemText(Models.Addresses.Address item)
        => item?.Name;

    protected override async Task OnParametersSetAsync()
    {
        Label = "Address";
        Placeholder = "Search by address...";

        await LoadItems();
    }

    public override async Task<IEnumerable<Models.Addresses.Address>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<Models.Addresses.Address>();

        return await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)));
    }

    private async Task LoadItems()
    {
        if (PersonId == 0 || _personId == PersonId)
            return;

        Entity.Address[] addresses = await Mediator.Send(new GetThroughTheMailAddresses(PersonId));

        Items = addresses.Select(address => new Models.Addresses.Address(address));

        _personId = PersonId;
    }
}
