namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PrivateSigningCustomItemGroupAutoComplete 
    : Autocomplete<Entity.PrivateSigningCustomItemGroup>
{
    [Parameter]
    public EventCallback ItemsReloaded { get; set; }

    [Parameter]
    public bool ReloadItems { get; set; }

    protected Entity.PrivateSigningCustomItemGroup[] Items { get; set; }
        = [];

    protected override async Task OnParametersSetAsync()
    {
        if (!ReloadItems)
            return;

        Items = await Mediator.Send(new GetPrivateSigningCustomItemGroups());

        await ItemsReloaded.InvokeAsync();
    }

    protected override async Task OnInitializedAsync()
    {
        Items = await Mediator.Send(new GetPrivateSigningCustomItemGroups());
        Label = "Custom Item Groups";
    }

    protected override string GetItemSelectedText(Entity.PrivateSigningCustomItemGroup item)
        => item.Name;

    protected override string GetItemText(Entity.PrivateSigningCustomItemGroup item)
        => item.Name;

    public override async Task<IEnumerable<Entity.PrivateSigningCustomItemGroup>> Search(string searchText)
        => !searchText.IsNullOrEmpty()
            ? await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)))
            : Array.Empty<Entity.PrivateSigningCustomItemGroup>();
}
