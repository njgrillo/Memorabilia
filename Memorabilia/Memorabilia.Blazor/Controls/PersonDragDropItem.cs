namespace Memorabilia.Blazor.Controls;

public class PersonDragDropItem : DragDropItem
{
    public string ImageFileName { get; set; }

    public Entity.Person Person { get; set; }
        = new();
}
