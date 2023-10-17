﻿namespace Memorabilia.Blazor.Controls.TypeAhead;

public class CollectionAutoComplete : Autocomplete<Entity.Collection>
{
    protected Entity.Collection[] Items { get; set; } 
        = Array.Empty<Entity.Collection>();

    protected override async Task OnInitializedAsync()
    {
        Items = await Mediator.Send(new GetCollections());
        Label = "Collections";
    }

    protected override string GetItemSelectedText(Entity.Collection item)
        => item.Name;

    protected override string GetItemText(Entity.Collection item)
        => item.Name;

    public override async Task<IEnumerable<Entity.Collection>> Search(string searchText)
        => !searchText.IsNullOrEmpty()
        ? await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)))
        : Array.Empty<Entity.Collection>();  
}
