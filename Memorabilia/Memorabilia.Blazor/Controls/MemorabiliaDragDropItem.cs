namespace Memorabilia.Blazor.Controls;

public class MemorabiliaDragDropItem : DragDropItem
{
    public Entity.Memorabilia Memorabilia { get; set; }
        = new();

    public string PersonName { get; set; }

    public string PrimaryImageFileName { get; set; }
}
