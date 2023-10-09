namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PrivateSigningCustomItemGroupAutoComplete : Autocomplete<Entity.PrivateSigningCustomItemGroup>
{
    protected Entity.PrivateSigningCustomItemGroup[] Items { get; set; }
        = Array.Empty<Entity.PrivateSigningCustomItemGroup>();

    protected override async Task OnInitializedAsync()
    {
        Items = await QueryRouter.Send(new GetPrivateSigningCustomItemGroups());
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
