namespace Memorabilia.Application.Features.Collection;

public class CollectionEditModel : EditModel
{
    public CollectionEditModel() { }

    public CollectionEditModel(Entity.Collection collection)
    {
        Description = collection.Description;
        Id = collection.Id;

        Items = collection.Memorabilia
                          .Select(item => new CollectionMemorabiliaEditModel(new CollectionMemorabiliaModel(item)))
                          .ToList();

        Name = collection.Name;
        UserId = collection.UserId;
    }

    public CollectionEditModel(CollectionModel model)
    {
        Description = model.Description;
        Id = model.Id;

        Items = model.Memorabilia
                     .Select(item => new CollectionMemorabiliaEditModel(new CollectionMemorabiliaModel(item)))
                     .ToList();

        Name = model.Name;
        UserId = model.UserId;
    }

    public string Description { get; set; }

    public List<CollectionMemorabiliaEditModel> Items { get; set; } 
        = new();

    public override string ItemTitle 
        => "Collection";

    public override string PageTitle 
        => "Collection";

    public override string RoutePrefix 
        => "MyStuff/Collections";

    public int UserId { get; set; }
}
