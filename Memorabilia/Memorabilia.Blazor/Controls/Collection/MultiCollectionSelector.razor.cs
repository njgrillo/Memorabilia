namespace Memorabilia.Blazor.Controls.Collection;

public partial class MultiCollectionSelector
{
    [Parameter]
    public List<Entity.Collection> SelectedCollections { get; set; } 
        = new();

    [Parameter]
    public int UserId { get; set; }

    protected Entity.Collection SelectedCollection { get; set; }

    protected void Add()
    {
        if (SelectedCollections == null)
            return;

        SelectedCollections.Add(SelectedCollection);
    }

    protected async Task Remove(Entity.Collection collection)
    {
        SelectedCollections.Remove(collection);

        await Task.CompletedTask;
    }
}
